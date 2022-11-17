using AutoMapper;
using CalibrationTracking.Infrastructure.Context;
using CalibrationTracking.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CalibrationTracking.Application.Calibrations.Commands.CreateCalibrationSku;

namespace CalibrationTracking.Application.Calibrations.Commands.CreateCalibrationSku
{
    public class CreateCalibrationSkuCommand : IRequest<Result<string>>
    {
        public class CreateCalibrationSkuCommandHandler : IRequestHandler<CreateCalibrationSkuCommand, Result<string>>
        {
            private readonly CalibrationDbContext _context;
            private readonly IMapper _mapper;
            private readonly Result<string> _result = new();

            public CreateCalibrationSkuCommandHandler(CalibrationDbContext context, IMapper mapper)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<Result<string>> Handle(CreateCalibrationSkuCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var count = await _context.Calibrations.CountAsync();
                    var barcode = MakeIntoSequence(count, 8);

                    _result.Value = barcode;

                    return _result;
                }
                catch (Exception ex)
                {
                    _result.AddServerError(ex.Message);

                    return _result;
                }
            }

            private string MakeIntoSequence(int i, int total_length, string prefix="")
            {
                string output = i.ToString();
                int length_minus_prefix = total_length - prefix.Length;
                while (output.Length < length_minus_prefix)
                    output = "0" + output;
                return output + prefix;
            }
        }
    }
}
