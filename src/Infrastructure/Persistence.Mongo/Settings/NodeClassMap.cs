using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.Node;
using MongoDB.Bson.Serialization;

namespace Persistence.Mongo.Settings
{
	public class NodeClassMap:MongodbClassMap<Node>
	{
		public override void Map(BsonClassMap<Node> cm)
		{
			cm.AutoMap();

			//every doc has to have an id
			cm.MapProperty(x => x.Port);
			cm.MapProperty(x => x.AccountName);
			cm.MapProperty(x => x.Ip);
			cm.MapProperty(x => x.Self);
			cm.MapProperty(x => x.Name);
		}
	}
}
