using MongoDB.Bson.Serialization;

namespace Persistence.Mongo.Settings;

public abstract class MongodbClassMap<T>
{
	protected MongodbClassMap()
	{
		if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
			BsonClassMap.RegisterClassMap<T>(Map);
	}

	public abstract void Map(BsonClassMap<T> cm);
}