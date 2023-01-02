using MongoDBPersistence.Base;

namespace MongoDBPersistence.Repositories.Block
{
	public class BlockCommandRepository : CommandRepository<Domain.Aggregates.Block.Block>, IBlockCommandRepository
	{
		public BlockCommandRepository(MongoContext context) : base(context)
		{
		}
	}
}
