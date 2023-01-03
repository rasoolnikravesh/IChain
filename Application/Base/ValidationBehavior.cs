using MediatR;

namespace Application.Base;

public class ValidationBehavior<TRequest, TResponse> : object,
	MediatR.IPipelineBehavior<TRequest, TResponse>
	where TRequest : MediatR.IRequest<TResponse>
{

	public ValidationBehavior
		(IEnumerable<FluentValidation.IValidator<TRequest>> validators)
	{
		Validators = validators;
	}

	protected IEnumerable<FluentValidation.IValidator<TRequest>> Validators { get; }
	
	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		if (Validators.Any())
		{
			var context =
				new FluentValidation.ValidationContext<TRequest>(request);

			var validationResults =
				await Task.WhenAll
					(Validators.Select(v => v.ValidateAsync(context, cancellationToken)));

			var failures =
					validationResults
						.SelectMany(current => current.Errors)
						.Where(current => current != null)
						.ToList()
				;

			if (failures.Count != 0)
			{
				throw new FluentValidation.ValidationException(errors: failures);
			}
		}

		return await next();
	}
}