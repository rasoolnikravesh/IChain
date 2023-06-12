using Application.Base;

namespace Application.Aggregates.Transaction.Commands;

public record CreateTransactionCommand : ICommand<Domain.Aggregates.Transaction.MoneyTransaction>
{
	public CreateTransactionCommand(string from, string to, double amount, double fee)
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