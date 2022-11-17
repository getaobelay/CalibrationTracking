using CalibrationTracking.Application.Employees.Queries.GetAllEmployees;
using FluentValidation;
using CalibrationTracking.Application.OrderSkus.Queries.GetOrderSku;

namespace CalibrationTracking.Application.OrderSkus.Queries.GetOrderSku
{
    public class GetOrderSkuQueryValidator : AbstractValidator<GetOrderSkuQuery>
    {
        public GetOrderSkuQueryValidator()
        {
        }
    }
}
