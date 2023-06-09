using Persistence.Mongo.Base;
using Persistence.Repositories.Transaction;

namespace Persistence.Mongo.Repositories.Transaction;

public class TransactionCommandRepository : CommandRepository<Domain.Aggregates.Transaction.BaseTransaction>, ITransactionCommandRepository
{
	public TransactionCommandRepository(MongoContext context) : base(context)
	{
		
	}
}