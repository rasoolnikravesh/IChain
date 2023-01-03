using Application.Base;

namespace Application.Aggregates.Transaction.Commands;

public class CreateTransaction : ICommand<Domain.Aggregates.Transaction.StringTransaction>
{
	public CreateTransaction(string from, string to, string data)
	{
		From = from;
		To = to;
		Data = data;
	}

	public string From { get; set; }

	public string To { get; set; }

	public string Data { get; set; }
}