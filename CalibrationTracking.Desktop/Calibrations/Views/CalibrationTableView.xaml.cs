using CalibrationTracking.Application.Calibrations.Commands.DeleteCalibration;
using CalibrationTracking.Application.Calibrations.Queries.GetAllCalibrations;
using CalibrationTracking.Application.Calibrations.Queries.GetSingleCalibration;
using CalibrationTracking.Core.Calibrations;
using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Calibrations.Windows;
using CalibrationTracking.Desktop.CustomeMessageBox;
using CalibrationTracking.Desktop.Services.CustomeMessageBox;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBoxButton = CalibrationTracking.Desktop.Services.CustomeMessageBox.MessageBoxButton;

namespace CalibrationTracking.Desktop.Calibrations.Views
{
    /// <summary>
    /// Interaction logic for CalibrationTableView.xaml
    /// </summary>
    public partial class CalibrationTableView : UserControl
    {
        public CalibrationTableView()
        {
            InitializeComponent();

            DataContext = new CalibrationListViewModel(this);
        }


  

        private void devicesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var filterdList = devicesDataGrid.SelectedItems.OfType<Calibration>().ToList();

                if (filterdList.Count > 1)
                {
                    ((CalibrationListViewModel)DataContext).SelectedCalibration = null;
                }
                else
                {
                    var row_list = GetDataGridRows(devicesDataGrid);
                    foreach (DataGridRow single_row in row_list)
                    {
                        if (single_row.IsSelected)
                        {
                            ((CalibrationListViewModel)DataContext).SelectedCalibration  = (Calibration)single_row.DataContext;
                        }
                    }
                }
            }
            catch { }
        }

        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var row_list = GetDataGridRows(devicesDataGrid);
            var calibrationId = Guid.Empty;

            foreach (DataGridRow single_row in row_list)
            {
                if (single_row.IsSelected)
                {
                    calibrationId = ((Calibration)single_row.DataContext).Id;

                           
                }
            }

            var query = new GetSingleCalibrationQuery
            {
                CalibrationId = calibrationId
            };


            Dispatcher.Invoke(async () =>
            {
                var result = await UserControlHelper.Mediator.Send(query);

                var _addOrEditWindow = new CalibrationAddOrEditWindow(this);

                _addOrEditWindow.DataContext = new CalibrationAddOrEditViewModel(_addOrEditWindow, result, this);

                _addOrEditWindow.Title.Text = "ערוך מכשיר";
                _addOrEditWindow.ShowDialog();
            });
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var row_list = GetDataGridRows(devicesDataGrid);
            Calibration calibration = null;

            foreach (DataGridRow single_row in row_list)
            {
                if (single_row.IsSelected)
                {
                    calibration = ((Calibration)single_row.DataContext);


                }
            }

        

            bool? Result = new CustomMessageBoxWindow($"האם אתה בטוח שברצנוך למחוק את המכשיר ? ", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {
                var command = new DeleteCalibrationCommand
                {
                    CalibrationId = calibration.Id,
                    CalibrationSku = calibration.CalibrationSKU
                };


                Dispatcher.Invoke(async () =>
                {
                    var result = await UserControlHelper.Mediator.Send(command);

                    if (result == true)
                    {
                        ((CalibrationListViewModel)DataContext).LoadData();
                    }
                });
            }


         
        }
    }
}
