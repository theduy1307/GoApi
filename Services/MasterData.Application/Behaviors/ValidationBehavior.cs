using FluentValidation;
using MediatR;

namespace MasterData.Application.Behaviors;

// This will collect fluent validators and run before handler
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            //This will run all the validation rules one by one and returns the validation result
            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            // Now need to chack for any failure
            var failure = validationResults.SelectMany(e => e.Errors)
                .Where(f => f != null)
                .ToList();
            if (failure.Count != 0)
            {
                throw new ValidationException(failure);
            }
        }
        // On success case
        return await next();
    }
}