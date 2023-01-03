using Domain.SeedWork;

namespace Application.Aggregates.Transaction.Events;

public class TransactionCreated : IDomainEvent
{
	public Guid Id { get; set; }

	public DateTime Created { get; set; }

	public string From { get; set; }

	public string To { get; set; }

	public string Data { get; set; }
}