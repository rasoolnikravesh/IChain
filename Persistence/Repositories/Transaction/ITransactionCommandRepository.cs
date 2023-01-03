using Persistence.Base;

namespace Persistence.Repositories.Transaction;

public interface ITransactionCommandRepository : ICommandRepository<Domain.Aggregates.Transaction.StringTransaction>
{

}