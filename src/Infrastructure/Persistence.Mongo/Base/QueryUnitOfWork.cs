﻿using System.Reflection;
using Domain.SeedWork;
using Persistence.Base;
using Persistence.RepositoryCollection;

namespace Persistence.Mongo.Base;

internal class QueryUnitOfWork : UnitOfWork, IQueryUnitOfWork
{
	public MongoContext Context { get; }

	public QueryUnitOfWork(MongoContext context, IRepositoryCollection repositoryCollection)
		: base(repositoryCollection)
	{
		Context = context;
	}

	public IQueryRepository<T> GetQueryRepository<T>() where T : class, IAggregateRoot
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

			RepositoryDescriptor newDescriptor = new(descriptor.RepositoryType, instance);
			RepositoryCollection.Remove(descriptor);
			RepositoryCollection.Add(newDescriptor);
			return (IQueryRepository<T>)instance;
		}
		return (IQueryRepository<T>)descriptor.ImplementationInstance;
	}

	public IQueryRepository<T> GetQueryRepository<T>(T obj) where T : class, IAggregateRoot
	{

		RepositoryDescriptor? descriptor = RepositoryCollection
			.FirstOrDefault(z => z.ImplementationType
				.GetInterfaces().Any(x => x.GenericTypeArguments.Any(y => y == obj.GetType())));
		if (descriptor is null)
			throw new ArgumentNullException();

		if (descriptor.ImplementationInstance == null)
		{
			ConstructorInfo? instanceCon =
				descriptor.ImplementationType.GetConstructor(new[] { Context.GetType() });
			object instance = instanceCon.Invoke(new object?[] { Context });

			RepositoryDescriptor newDescriptor = new(descriptor.RepositoryType, instance);
			RepositoryCollection.Remove(descriptor);
			RepositoryCollection.Add(newDescriptor);
			return (IQueryRepository<T>)instance;
		}
		return (IQueryRepository<T>)descriptor.ImplementationInstance;
	}

}