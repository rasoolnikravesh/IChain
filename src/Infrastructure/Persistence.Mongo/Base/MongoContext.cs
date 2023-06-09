using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Persistence.Mongo.Settings;

namespace Persistence.Mongo.Base;

public class MongoContext
{
	public IMongoClient MongoClient { get; init; }
	public IMongoDatabase Database { get; init; }

	public MongoContext(InitialSetting setting)
	{
		MongoClient = new MongoClient(setting.ConnectionString);

		BsonSerializer.RegisterSerializationProvider(new CsharpLegacyGuidSerializationProvider());

		Database = MongoClient.GetDatabase(setting.DataBase);
	}
}

class CsharpLegacyGuidSerializationProvider : IBsonSerializationProvider
{
	public IBsonSerializer? GetSerializer(Type type)
	{
		return type == typeof(Guid) ? new GuidSerializer(GuidRepresentation.CSharpLegacy) : null;
	}
}
