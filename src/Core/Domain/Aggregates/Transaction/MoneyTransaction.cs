using Domain.SeedWork;
using FluentResults;
using Utility;

namespace Domain.Aggregates.Transaction;

public class MoneyTransaction : BaseTransaction
{
	public static Result<MoneyTransaction> Create(string from, string to,
		double amount, double fee, string signature, string publicKey)
	{
		Result<MoneyTransaction> result = new();

		var account = new Account().SetPublicKey(publicKey).GetAddress();

		if (from != account)
		{
			result.WithError("From Account Address And Public Key Is not Match.");
		}

		var signData = $"{from}-{to}-{amount}-{fee}";

		var verifySignature = new Account().SetPublicKey(publicKey).VerifySign(signData, signature);

		if (!verifySignature)
		{
			result.WithError("Signature is Not Valid!");
		}

		if (result.Errors.Any())
		{
			return result;
		}

		MoneyTransaction r = new(from, to, amount, fee, signature, publicKey);


		result.WithValue(r);

		return result;
	}

#pragma warning disable CS8618
	private MoneyTransaction()
#pragma warning restore CS8618
	{

	}

	private MoneyTransaction(string from, string to,
		double amount, double fee, string signature, string publicKey) : base(from, to, signature, publicKey)
	{
		Amount = amount;
		Fee = fee;
	}


	public double Amount { get; }
	public double Fee { get; }

	public override string GetHashData()
	{
		return $"{From}-{To}-{Amount}-{Fee}";
	}
}