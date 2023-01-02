using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBPersistence.Base;

namespace MongoDBPersistence.Repositories.Transaction
{
	public class TransactionQueryRepository : QueryRepository<Domain.Aggregates.Transaction.Transaction>, ITransactionQueryRepository
	{
		public TransactionQueryRepository(MongoContext context) : base(context)
		{
		}
	}
}
