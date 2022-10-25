using CalibrationTracking.Desktop.Departments.ViewModels;
using System;
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
using System.Windows.Shapes;

namespace CalibrationTracking.Desktop.Departments.Windows
{
    /// <summary>
    /// Interaction logic for DepartmentAddOrEditWindow.xaml
    /// </summary>
    public partial class DepartmentAddOrEditWindow : Window
    {
        public DepartmentAddOrEditWindow(MediatR.IMediator mediator)
        {
            InitializeComponent();

            DataContext = new DepartmentAddOrEditViewModel(mediator, this, null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
