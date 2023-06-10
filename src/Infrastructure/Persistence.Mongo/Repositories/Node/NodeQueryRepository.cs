using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Mongo.Base;
using Persistence.Repositories.Node;

namespace Persistence.Mongo.Repositories.Node
{
	internal class NodeQueryRepository : QueryRepository<Domain.Aggregates.Node.Node>, INodeQueryRepository
	{
		public NodeQueryRepository(MongoContext context) : base(context)
		{
		}
	}
}
