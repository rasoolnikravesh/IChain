using System.Text.Json.Serialization;

namespace Domain.SeedWork;

public class AggregateRoot : Entity, IAggregateRoot
{

	public AggregateRoot()
	{
		_domainEvents = new List<IDomainEvent>();
		RegisterDate = Utility.Now;
		Id = Guid.NewGuid();
	}

	public void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}
	[JsonIgnore]
	private readonly List<IDomainEvent> _domainEvents;
	[JsonIgnore]
	public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

	public void RaiseDomainEvent(IDomainEvent? domainEvent)
	{
		if (domainEvent is not null)
			_domainEvents.Add(domainEvent);
	}

	public void RemoveDomainEvent(IDomainEvent? domainEvent)
	{
		if (domainEvent is not null)
			_domainEvents.Remove(domainEvent);
	}

}