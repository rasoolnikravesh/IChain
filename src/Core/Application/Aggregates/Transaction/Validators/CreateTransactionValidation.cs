using Application.Aggregates.Transaction.Commands;
using FluentValidation;

namespace Application.Aggregates.Transaction.Validators;

public class CreateTransactionValidation : AbstractValidator<CreateTransactionCommand>
{
	public CreateTransactionValidation()
	{
		RuleFor(x => x.To).NotNull();
		RuleFor(x => x.From).NotNull();
		RuleFor(x => x.Amount).NotNull();
		RuleFor(x => x.Fee).NotNull();
	}
}