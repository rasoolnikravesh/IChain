using MongoDBPersistence.Base;
using Persistence.Repositories.Transaction;

namespace MongoDBPersistence.Repositories.Transaction;

public class TransactionCommandRepository : CommandRepository<Domain.Aggregates.Transaction.StringTransaction>, ITransactionCommandRepository
{
	public TransactionCommandRepository(MongoContext context) : base(context)
	{
	}
}