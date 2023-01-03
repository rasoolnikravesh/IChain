using Domain.SeedWork;

namespace Domain.Aggregates.Transaction;

public class Transaction : AggregateRoot
{
#pragma warning disable CS8618
	public Transaction()
#pragma warning restore CS8618
	{

	}

	public Transaction(string from, string to, string data)
	{
		From = from;
		To = to;
		Data = data;
	}

	public string From { get; set; }
	public string To { get; set; }

	public string Data { get; set; }
}