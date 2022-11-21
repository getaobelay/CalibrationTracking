using MediatR;
using CalibrationTracking.Infrastructure.Context;
using CalibrationTracking.Application.OrderSkus.Queries.GetOrderSku;
using CalibrationTracking.Application.Employees.Queries.GetAllEmployees;
using Microsoft.EntityFrameworkCore;
using CalibrationTracking.Core;

namespace CalibrationTracking.Application.OrderSkus.Queries.GetOrderSku
{
    public class GetOrderSkuQuery : IRequest<OrderSku>
    {
        public class GetOrderSkuQueryHandler : IRequestHandler<GetOrderSkuQuery, OrderSku>
        {
            private readonly CalibrationDbContext _context;

            public GetOrderSkuQueryHandler(CalibrationDbContext context)
            {
                _context = context;
            }

            public async Task<OrderSku> Handle(GetOrderSkuQuery request, CancellationToken cancellationToken)
            {
                if (!_context.OrderSku.Any())
                {
                    await _context.AddAsync(new OrderSku { Counter = 4397 });
                    await _context.SaveChangesAsync();

                }
                return await _context.OrderSku.FirstAsync();
            }
        }
    }
}
