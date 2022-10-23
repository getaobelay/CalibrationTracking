using CalibrationTracking.Desktop.Employees.ViewModels;
using CalibrationTracking.Infrastructure.Interfaces;
using MediatR;
using System.Windows;

namespace CalibrationTracking.Desktop.Employees.Windows
{
    /// <summary>
    /// Interaction logic for AddOrEditEmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeAddOrEditWindow : Window
    {
        public EmployeeAddOrEditWindow(IEmployeeRepository employeeRepository, IMediator mediator)
        {
            InitializeComponent();

            DataContext = new EmployeeAddOrEditViewModel(null, this, mediator);
        }

    }
}