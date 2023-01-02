using System.Reflection;
using Domain.SeedWork;
using Persistence;
using Persistence.Base;
using Persistence.RepositoryCollection;

namespace MongoDBPersistence.Base;

internal class CommandUnitOfWork : UnitOfWork, ICommandUnitOfWork
{
	public MongoContext Context { get; }


	public CommandUnitOfWork(MongoContext context, IRepositoryCollection repositoryCollection)
		: base(repositoryCollection)
	{
		Context = context;
	}

	public ICommandRepository<T> GetCommandRepository<T>() where T : class, IAggregateRoot
	{
		RepositoryDescriptor? descriptor = RepositoryCollection
			.FirstOrDefault(z => z.ImplementationType
				.GetInterfaces().Any(x => x.GenericTypeArguments.Any(y => y == typeof(T))));
		if (descriptor is null)
			throw new ArgumentNullException();

		if (descriptor.ImplementationInstance == null)
		{
			ConstructorInfo? instanceCon =
				descriptor.ImplementationType.GetConstructor(new[] { Context.GetType() });
			object instance = instanceCon.Invoke(new object?[] { Context });

			RepositoryDescriptor newDescriptor = new RepositoryDescriptor(descriptor.RepositoryType, instance);
			RepositoryCollection.Remove(descriptor);
			RepositoryCollection.Add(newDescriptor);
			return (ICommandRepository<T>)instance;
		}
		return (ICommandRepository<T>)descriptor.ImplementationInstance;

	}
}