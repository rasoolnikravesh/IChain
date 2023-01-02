using Persistence.Base;

namespace MongoDBPersistence.Repositories.Transaction;

public interface ITransactionQueryRepository : IQueryRepository<Domain.Aggregates.Transaction.Transaction>
{

}