using MediatR;

namespace CalibrationTracking.Abstractions.Behaviors
{
    public interface IPipelineBehaviour<in TRequest, TResponse> where TRequest : notnull
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next);
    }

}
