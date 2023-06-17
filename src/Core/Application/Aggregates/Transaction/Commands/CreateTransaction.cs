using Application.Base;

namespace Application.Aggregates.Transaction.Commands;

public record CreateTransactionCommand : ICommand<Domain.Aggregates.Transaction.MoneyTransaction>
{
	public CreateTransactionCommand(string from, string to, double amount, double fee, string signature, string publicKey)
	{
		From = from;
		To = to;
		Amount = amount;
		Fee = fee;
		Signature = signature;
		PublicKey = publicKey;
	}

	public string From { get; }

	public string To { get; }

	public double Amount { get; }

	public double Fee { get; }

	public string Signature { get; }

	public string PublicKey { get; }
}