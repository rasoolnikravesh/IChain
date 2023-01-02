using MongoDB.Bson.Serialization.Attributes;

namespace Domain.SeedWork;

public class Entity : IEntity
{
	public static bool operator ==(Entity? left, Entity? right)
	{
		return left switch
		{
			null when right is null => true,
			null => false,
			_ => right is not null && left.Equals(right),
		};
	}

	public static bool operator !=(Entity? left, Entity? right)
	{
		return !(left == right);
	}

	public Guid Id { get; set; }

	public DateTime RegisterDate { get; set; }

	[BsonIgnore]
	public int? _requestedHashCode;

	public bool IsTransient() => Id == default;

	public override bool Equals(object? anotherObject)
	{
		switch (anotherObject)
		{
			case null:
			case Entity:
				return false;
		}

		if (ReferenceEquals(this, anotherObject))
			return true;
		Entity? anotherEntity = anotherObject as Entity;
		if (GetRealType() != anotherEntity?.GetRealType())
			return false;
		if (GetType() != anotherEntity?.GetType())
			return false;
		if (IsTransient() || anotherEntity.IsTransient())
			return false;
		return Id == anotherEntity.Id;
	}

	public override int GetHashCode()
	{
		if (IsTransient()) return base.GetHashCode();
		_requestedHashCode ??= Id.GetHashCode();
		return _requestedHashCode.Value;
	}
	private Type? GetRealType()
	{
		Type type = GetType();
		return type.ToString().Contains("Castle.Proxies.") ? type.BaseType : type;
	}
}