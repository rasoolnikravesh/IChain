using Persistence.Base;

namespace Persistence.Repositories.Transaction;

public interface ITransactionQueryRepository : IQueryRepository<Domain.Aggregates.Transaction.StringTransaction>
{

}