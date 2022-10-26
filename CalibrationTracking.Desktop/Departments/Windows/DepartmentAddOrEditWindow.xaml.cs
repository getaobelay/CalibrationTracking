using System.Windows;
using CalibrationTracking.Desktop.Departments.ViewModels;

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
