using Domain.SeedWork;
using Persistence.Base;

namespace Persistence;

public interface IQueryUnitOfWork : IUnitOfWork
{
	IQueryRepository<T> GetQueryRepository<T>() where T : class, IAggregateRoot;

	IQueryRepository<T> GetQueryRepository<T>(T obj) where T : class, IAggregateRoot;

}