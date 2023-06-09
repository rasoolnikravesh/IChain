using Application.Base;

namespace Application.Aggregates.Transaction.Commands;

public record CreateTransaction : ICommand<Domain.Aggregates.Transaction.MoneyTransaction>
{
	public CreateTransaction(string from, string to, double amount, double fee)
	{
		From = from;
		To = to;
		Amount = amount;
		Fee = fee;
	}

	public string From { get; }

	public string To { get; }

	public double Amount { get; }

	public double Fee { get; }
}