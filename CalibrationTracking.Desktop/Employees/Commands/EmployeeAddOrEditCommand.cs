﻿using CalibrationTracking.Desktop.Base;
using CalibrationTracking.Desktop.Employees.ViewModels;
using CalibrationTracking.Desktop.Employees.Windows;
using MediatR;
using System.Threading.Tasks;
using CalibrationTracking.Application.Employees.Commands.CreateEmployee;

namespace CalibrationTracking.Desktop.Employees.Commands
{
    public class EmployeeAddOrEditCommand : AsyncCommand
    {
        private readonly IMediator _mediator;
        private readonly EmployeeAddOrEditWindow _employeeAddOrEditWindow;
        private readonly EmployeeListWindow _employeeListWindow;

        public EmployeeAddOrEditCommand(EmployeeAddOrEditWindow employeeAddOrEditWindow, IMediator mediator)
        {
            _mediator = mediator;
            _employeeAddOrEditWindow = employeeAddOrEditWindow;
            _employeeListWindow = new(mediator);
        }



        public override bool CanExecute()
        {
            var viewModel = (EmployeeAddOrEditViewModel)_employeeAddOrEditWindow.DataContext;

            bool canSaveForm = !string.IsNullOrWhiteSpace(viewModel.FirstName) && !string.IsNullOrWhiteSpace(viewModel.LastName);

            return canSaveForm;
        }

        public override async Task ExecuteAsync()
        {
            var viewModel = (EmployeeAddOrEditViewModel)_employeeAddOrEditWindow.DataContext;

            var command = new CreateEmployeeCommand
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                DepartmentId = viewModel.SelectedDepartment.Id,
            };

            var result = await _mediator.Send(command);

         
            if(result is not null)
            {
                _employeeListWindow.Show();
            }
            
        }
    }
}