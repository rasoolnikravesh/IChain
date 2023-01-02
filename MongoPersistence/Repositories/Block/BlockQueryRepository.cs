using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBPersistence.Base;

namespace MongoDBPersistence.Repositories.Block
{
	public class BlockQueryRepository : QueryRepository<Domain.Aggregates.Block.Block>,IBlockQueryRepository
	{
		public BlockQueryRepository(MongoContext context) : base(context)
		{
		}
	}
}
