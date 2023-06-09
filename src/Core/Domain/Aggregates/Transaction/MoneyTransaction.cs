using Domain.SeedWork;
using FluentResults;

namespace Domain.Aggregates.Transaction;

public class MoneyTransaction : BaseTransaction
{
	public static Result<MoneyTransaction> Create(string from, string to, double amount, double fee)
	{
		Result<MoneyTransaction> result = new();

		var r = Create(from, to);
		if (r.IsSuccess)
		{
			result.WithValue(new MoneyTransaction(from, to, amount, fee));

		}
		return result;
	}

#pragma warning disable CS8618
	private MoneyTransaction()
#pragma warning restore CS8618
	{

	}

	private MoneyTransaction(string from, string to, double amount, double fee) : base(from, to)
	{
		Amount = amount;
		Fee = fee;
	}


	public double Amount { get; }
	public double Fee { get; }
}