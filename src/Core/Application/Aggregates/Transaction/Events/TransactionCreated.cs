using Domain.SeedWork;

namespace Application.Aggregates.Transaction.Events;

public class TransactionCreated<T> : IDomainEvent
{
	public Guid Id { get; set; }

	public DateTime Created { get; set; }

	public string From { get; set; }

	public string To { get; set; }

	public T Data { get; set; }

	public double Fee { get; set; }
}