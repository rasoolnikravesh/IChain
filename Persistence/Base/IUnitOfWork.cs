using Persistence.RepositoryCollection;

namespace Persistence.Base;

public interface IUnitOfWork : IDisposable
{
	bool IsDisposed { get; }
	IRepositoryCollection RepositoryCollection { get; }

	//Task<int> SaveAsync();
}