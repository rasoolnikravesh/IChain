using MongoDBPersistence.Base;
using Persistence.Repositories.Transaction;

namespace MongoDBPersistence.Repositories.Transaction;

public class TransactionQueryRepository : QueryRepository<Domain.Aggregates.Transaction.StringTransaction>, ITransactionQueryRepository
{
	public TransactionQueryRepository(MongoContext context) : base(context)
	{
	}
}