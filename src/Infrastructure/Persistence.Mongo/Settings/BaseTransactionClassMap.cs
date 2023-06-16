using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.Transaction;
using MongoDB.Bson.Serialization;

namespace Persistence.Mongo.Settings
{
	internal class BaseTransactionClassMap : MongodbClassMap<BaseTransaction>
	{
		public override void Map(BsonClassMap<BaseTransaction> cm)
		{
			cm.AutoMap();
			cm.MapMember(transaction => transaction.Hash);
			cm.MapMember(transaction => transaction.From);
			cm.MapMember(transaction => transaction.To);
		}
	}

	internal class MoneyTransactionClassMap : MongodbClassMap<MoneyTransaction>
	{
		public override void Map(BsonClassMap<MoneyTransaction> cm)
		{
			cm.AutoMap();
			cm.SetDiscriminator(nameof(MoneyTransaction));
			cm.MapProperty(transaction => transaction.Fee);
			cm.MapProperty(transaction => transaction.Amount);
		}
	}
}
