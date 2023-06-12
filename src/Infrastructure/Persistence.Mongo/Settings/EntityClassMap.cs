using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.SeedWork;
using MongoDB.Bson.Serialization;

namespace Persistence.Mongo.Settings
{
	internal class EntityClassMap : MongodbClassMap<Entity>
	{
		public override void Map(BsonClassMap<Entity> cm)
		{
			cm.AutoMap();
			cm.MapIdMember(entity => entity.Id).SetOrder(1);
		}
	}
}
