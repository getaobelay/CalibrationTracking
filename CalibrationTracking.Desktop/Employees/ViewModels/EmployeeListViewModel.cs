using CalibrationTracking.Application.Employees.Queries.GetAllEmployees;
using CalibrationTracking.Core.Employees;
using CalibrationTracking.Desktop.Base;
using MediatR;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CalibrationTracking.Desktop.Employees.ViewModels
{
    internal class EmployeeListViewModel : BaseViewModel
    {
        private readonly IMediator _mediator;

        public EmployeeListViewModel(IMediator mediator) 
        {

            _mediator = mediator;

            LoadDataAsync();

        }

        private async void LoadDataAsync()
        {
            await GetAllEmployees();
        }

        private ObservableCollection<Employee>? _employees;

        public ObservableCollection<Employee>? Employees
        { get { return _employees; } set { _employees = value; RaisePropertyChanged(); } }




        private async Task GetAllEmployees()
        {
            var query = new GetAllEmployeesQuery();

            var employees = await _mediator.Send(query);

            _employees = new(employees);

            RaisePropertyChanged(nameof(Employees));
        }
    }
}