using Persistence.RepositoryCollection;

namespace Persistence.Base;

public class UnitOfWork : IUnitOfWork

{
	public UnitOfWork(IRepositoryCollection repositoryCollection)
	{
		RepositoryCollection = repositoryCollection;
	}
	public virtual void Dispose(bool disposing)
	{
		if (IsDisposed)
			return;
		if (disposing)
			RepositoryCollection.Dispose();
		IsDisposed = true;
	}

	public bool IsDisposed { get; protected set; }

	public IRepositoryCollection RepositoryCollection { get; }


	~UnitOfWork()
	{

		Dispose(false);
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
}