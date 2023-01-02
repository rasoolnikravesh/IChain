using Persistence.Base;

namespace MongoDBPersistence.Repositories.Transaction;

public interface ITransactionCommandRepository : ICommandRepository<Domain.Aggregates.Transaction.Transaction>
{

}