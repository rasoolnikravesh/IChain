using Persistence.Mongo.Base;
using Persistence.Repositories.Transaction;

namespace Persistence.Mongo.Repositories.Transaction;

public class TransactionQueryRepository : QueryRepository<Domain.Aggregates.Transaction.MoneyTransaction>, ITransactionQueryRepository
{
	public TransactionQueryRepository(MongoContext context) : base(context)
	{
	}
}