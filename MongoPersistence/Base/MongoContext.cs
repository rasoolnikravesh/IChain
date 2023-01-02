using Domain.Aggregates.Transaction;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using MongoDBPersistence.Settings;

namespace MongoDBPersistence.Base;

public class MongoContext
{
	public IMongoClient MongoClient { get; init; }
	public IMongoDatabase Database { get; init; }

	public MongoContext(InitialSetting setting)
	{
		MongoClient = new MongoClient(setting.ConnectionString);

		//BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

		//BsonClassMap.RegisterClassMap<Transaction>(setting =>
		//{
		//	setting.AutoMap();

		//});

		Database = MongoClient.GetDatabase(setting.DataBase);
	}
}