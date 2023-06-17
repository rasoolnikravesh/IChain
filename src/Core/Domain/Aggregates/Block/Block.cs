using Domain.Aggregates.Transaction;
using Domain.SeedWork;
using FluentResults;

namespace Domain.Aggregates.Block;

public class Block : AggregateRoot
{
#pragma warning disable CS8618
	// ReSharper disable once UnusedMember.Local
	private Block()
#pragma warning restore CS8618
	{
		_transactions = new List<BaseTransaction>();
	}

	private Block(DateTime timeStamp, string prevHash, long index)
	{
		TimeStamp = timeStamp;
		PrevHash = prevHash;
		Index = index;

		_transactions = new List<BaseTransaction>();
	}


	public static Result<Block> Create(string prevHash, long index)
	{
		var result = new Result<Block>();

		if (string.IsNullOrEmpty(prevHash))
		{
			result.WithError("Prev Hash Is Required.");
		}

		if (result.Errors.Any())
			return result;

		Block block = new Block(DateTime.UtcNow, prevHash, index);

		result.WithValue(block);

		return result;


	}


	public Result AddTransaction(BaseTransaction transaction)
	{
		_transactions!.Add(transaction);

		return Result.Ok();
	}

	public Result RemoveTransaction(BaseTransaction transaction)
	{
		var result = _transactions!.Remove(transaction);

		return result ? Result.Ok() : Result.Fail("");
	}


	public Result<string> ComputeHash()
	{
		Hash = "";
		throw new NotImplementedException();
	}


	public DateTime TimeStamp { get; }

	public string? Hash { get; private set; }

	public string PrevHash { get; }

	public long Index { get; }

	private List<BaseTransaction>? _transactions;

	public IReadOnlyList<BaseTransaction> Transactions => _transactions ??= new List<BaseTransaction>();
}