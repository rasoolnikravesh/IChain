using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.SeedWork;
using MediatR;
using Persistence;
using Persistence.Base;

namespace Application.Base
{
	public class EventBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		public IQueryUnitOfWork UnitOfWork { get; }

		public EventBehavior(IQueryUnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{

			//var objType = request
			//	.GetType()
			//	.GetInterfaces()
			//	.SelectMany(x => x.GenericTypeArguments)
			//	.FirstOrDefault(x => x.GetInterfaces().Any(y => y == typeof(IAggregateRoot)));

			//ConstructorInfo? instanceCon =
			//	objType.GetConstructor(Type.EmptyTypes);
			//if (instanceCon != null)
			//{

			//	object instance = instanceCon.Invoke(new object?[] { });
			//	dynamic t = instance;

			//	var r = UnitOfWork.GetQueryRepository(Convert.ChangeType(t, objType));
				

			//}

			TResponse response = await next();

			Console.WriteLine("After");

			return response;
		}
	}
}
