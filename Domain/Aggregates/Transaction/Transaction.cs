using Domain.SeedWork;

namespace Domain.Aggregates.Transaction;

public class Transaction : AggregateRoot
{
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