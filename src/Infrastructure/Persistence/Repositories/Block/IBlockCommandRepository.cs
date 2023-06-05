using Persistence.Base;

namespace Persistence.Repositories.Block;

public interface IBlockCommandRepository : ICommandRepository<Domain.Aggregates.Block.Block>
{

}