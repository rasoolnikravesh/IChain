using System.Collections;

namespace Persistence.RepositoryCollection;

public class RepositoryCollection : IRepositoryCollection
{
	#region Collection

	private readonly List<RepositoryDescriptor> _descriptors = new();

	public int Count => this._descriptors.Count;

	public bool IsReadOnly => false;

	public RepositoryDescriptor this[int index]
	{
		get => this._descriptors[index];
		set => this._descriptors[index] = value;
	}

	public void Clear() => this._descriptors.Clear();

	public bool Contains(RepositoryDescriptor item) => this._descriptors.Contains(item);

	public void CopyTo(RepositoryDescriptor[] array, int arrayIndex) => this._descriptors.CopyTo(array, arrayIndex);

	public bool Remove(RepositoryDescriptor item) => this._descriptors.Remove(item);

	public IEnumerator<RepositoryDescriptor> GetEnumerator() => this._descriptors.GetEnumerator();

	void ICollection<RepositoryDescriptor>.Add(RepositoryDescriptor item) => this._descriptors.Add(item);

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


	public int IndexOf(RepositoryDescriptor item) => this._descriptors.IndexOf(item);

	public void Insert(int index, RepositoryDescriptor item) => this._descriptors.Insert(index, item);

	public void RemoveAt(int index) => this._descriptors.RemoveAt(index);

	#endregion

	public virtual void Dispose(bool disposing)
	{
		if (IsDisposed)
			return;
		if (disposing)
		{
			foreach (IDisposable obj in _descriptors.OfType<IDisposable>())
			{
				obj.Dispose();
			}

			_descriptors.Clear();
		}
		IsDisposed = true;
	}

	public bool IsDisposed { get; protected set; }



	~RepositoryCollection()
	{

		Dispose(false);
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}


	public object Shallowcopy()
	{
		return this.MemberwiseClone();
	}

	// method for cloning object
	public RepositoryCollection DeepCopy()
	{
		RepositoryCollection deepCopyCompany = new RepositoryCollection();
		deepCopyCompany._descriptors.AddRange(_descriptors);
		return deepCopyCompany;
	}
}