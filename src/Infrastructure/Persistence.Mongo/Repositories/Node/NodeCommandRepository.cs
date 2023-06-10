using Persistence.Mongo.Base;
using Persistence.Repositories.Node;

namespace Persistence.Mongo.Repositories.Node
{
	public class NodeCommandRepository : CommandRepository<Domain.Aggregates.Node.Node>, INodeCommandRepository
	{
		public NodeCommandRepository(MongoContext context) : base(context)
		{
		}
	}

}
