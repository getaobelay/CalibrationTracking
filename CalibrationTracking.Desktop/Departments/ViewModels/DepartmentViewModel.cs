﻿using CalibrationTracking.Desktop.Base;
using MediatR;

namespace CalibrationTracking.Desktop.Departments.ViewModels
{
    internal class DepartmentViewModel : BaseViewModel
    {
        private readonly IMediator _mediator;

        public DepartmentViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (!string.Equals(_name, value))
                {
                    _name = value;
                    RaisePropertyChanged();
                }
            }
        }


        private string _description;

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                if (!string.Equals(_description, value))
                {
                    _description = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}