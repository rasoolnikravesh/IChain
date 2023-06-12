using Domain.SeedWork;

namespace Application.Aggregates.Transaction.Events;

public class TransactionReceived : IDomainEvent
{
	public Guid Id { get; set; }

	public DateTime Created { get; set; }

	public string From { get; set; }

	public string To { get; set; }

	public string Data { get; set; }
}