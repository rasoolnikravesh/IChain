namespace Persistence.RepositoryCollection;

public interface IRepositoryCollection :
	IList<RepositoryDescriptor>,
	ICollection<RepositoryDescriptor>,
	IEnumerable<RepositoryDescriptor>,
	IDisposable
{

}