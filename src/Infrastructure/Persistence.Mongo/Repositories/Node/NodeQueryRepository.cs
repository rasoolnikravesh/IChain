using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Persistence.Mongo.Base;
using Persistence.Repositories.Node;

namespace Persistence.Mongo.Repositories.Node
{
	internal class NodeQueryRepository : QueryRepository<Domain.Aggregates.Node.Node>, INodeQueryRepository
	{
		public NodeQueryRepository(MongoContext context) : base(context)
		{
		}

		public async Task<bool> SelfNodeConfiged()
		{

			try
			{
				Domain.Aggregates.Node.Node? result = await Collection.AsQueryable().Where(x => x.Self).SingleOrDefaultAsync();
				return result != null;
			}
			catch (Exception ex)
			{

				return false;
			}
		}
	}
}
