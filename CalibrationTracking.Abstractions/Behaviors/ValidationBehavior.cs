using CalibrationTracking.Abstractions.Exceptions;
using CalibrationTracking.Shared;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CalibrationTracking.Abstractions.Behaviors
{
    public sealed class ValidationBehaviour<TRequest, TResponse> : IPipelineBehaviour<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
    where TResponse : Result<TResponse>, new()
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger _logger;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators, ILogger logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            // If no validators have been defined for the currently executing request exit
            if (!_validators.Any()) return await next();
            // Check the currently executing context for any validation errors
            var context = new ValidationContext<TRequest>(request);
            var validationResults =
                await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            // if now failures exit
            if (!failures.Any()) return await next();
            // If we have failures iterate through them all get the details and then our Validation Error
            List<string> errors = new();

            failures.ForEach(f =>
            {
                var errorMessage = $"Validation Error: {f.PropertyName} {f.Severity} {f.AttemptedValue}";

                _logger.LogInformation(errorMessage);

                errors.Add(errorMessage);
            });

            throw new ValidatioFailedException(errors);
        }
    }
}