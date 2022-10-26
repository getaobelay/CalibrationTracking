using CalibrationTracking.Core.Calibrations;
using CalibrationTracking.Desktop.Base;
using MediatR;

namespace CalibrationTracking.Desktop.Calibrations.ViewModels
{
    internal class CalibrationViewModel : BaseViewModel<Calibration>
    {
        private readonly IMediator _mediator;

        public CalibrationViewModel(IMediator mediator, Calibration model):base(model)
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
