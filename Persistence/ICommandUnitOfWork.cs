using Domain.SeedWork;
using Persistence.Base;

namespace Persistence;

public interface ICommandUnitOfWork : IUnitOfWork
{
	ICommandRepository<T> GetCommandRepository<T>() where T : class, IAggregateRoot;

}