using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBPersistence.Base;

namespace MongoDBPersistence.Repositories.Transaction
{
	public class TransactionCommandRepository : CommandRepository<Domain.Aggregates.Transaction.Transaction>, ITransactionCommandRepository
	{
		public TransactionCommandRepository(MongoContext context) : base(context)
		{
		}
	}
}
