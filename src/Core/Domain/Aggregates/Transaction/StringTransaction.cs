using Domain.SeedWork;
using FluentResults;

namespace Domain.Aggregates.Transaction;

public class StringTransaction : BaseTransaction
{
	public static Result<StringTransaction> Create(string From, string To, string data)
	{
		Result<StringTransaction> result = new();

		var r = Create(From, To);
		if (r.IsSuccess)
		{
			result.WithValue(new StringTransaction(From, To, data));

		}
		return result;
	}

#pragma warning disable CS8618
	private StringTransaction()
#pragma warning restore CS8618
	{

	}

	private StringTransaction(string from, string to, string data) : base(from, to)
	{
		Data = data;
	}


	public string Data { get; set; }
}