using Domain.SeedWork;

namespace Application.Aggregates.Transaction.Events;

public class MoneyTransactionCreated : IDomainEvent
{
	public Guid Id { get; set; }

	public DateTime Created { get; set; }

	public string From { get; set; }

	public string To { get; set; }

	public double Amount { get; set; }

	public double Fee { get; set; }

	public string Signature { get; set; }

	public string PublicKey { get; set; }

}