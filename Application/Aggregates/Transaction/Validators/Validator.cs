using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Aggregates.Transaction.Commands;
using Application.Base;
using FluentValidation;

namespace Application.Aggregates.Transaction.Validators;

public class CreateTransactionValidation : AbstractValidator<CreateTransaction>
{
	public CreateTransactionValidation()
	{
		RuleFor(x => x.To).NotNull();
		RuleFor(x => x.From).NotNull();
		RuleFor(x => x.Data).NotNull();
	}
}