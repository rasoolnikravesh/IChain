using MongoDB.Bson.Serialization.Attributes;

namespace Domain.SeedWork;

public interface IEntity
{
	[BsonId]
	public Guid Id { get; set; }

}