using Persistence.Mongo.Base;
using Persistence.Repositories.Block;

namespace Persistence.Mongo.Repositories.Block;

public class BlockCommandRepository : CommandRepository<Domain.Aggregates.Block.Block>, IBlockCommandRepository
{
	public BlockCommandRepository(MongoContext context) : base(context)
	{
	}
}