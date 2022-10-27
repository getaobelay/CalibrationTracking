using CalibrationTracking.Desktop.Calibrations.ViewModels;
using CalibrationTracking.Desktop.Employees.ViewModels;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Collections;

namespace CalibrationTracking.Desktop.Calibrations.Windows
{
    /// <summary>
    /// Interaction logic for CalibrationListWindow.xaml
    /// </summary>
    public partial class CalibrationListWindow : Window
    {
  

        public CalibrationListWindow(IMediator mediator)
        {
            InitializeComponent();

            AppDomain.CurrentDomain.FirstChanceException += (source, e) =>
            {
                Debug.WriteLine("FirstChanceException event raised in {0}: {1}",
                    AppDomain.CurrentDomain.FriendlyName, e.Exception.Message);
            };


            DataContext = new CalibrationListViewModel(mediator);
        }





        #region Private Methods

        /// <summary>
        /// Add line numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var index = e.Row.GetIndex() + 1;
            e.Row.Header = $"{index}";
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

        #endregion Private Methods

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
    }
}
