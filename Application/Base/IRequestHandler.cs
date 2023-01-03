using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using MediatR;

namespace Application.Base
{
	public interface ICommandHandler<in TCommand> :
		MediatR.IRequestHandler<TCommand, FluentResults.Result>
		where TCommand : IRequest<Result>
	{

	}

	public interface ICommandHandler<in TCommand, TReturnValue> :
		MediatR.IRequestHandler<TCommand, FluentResults.Result<TReturnValue>>
		where TCommand : MediatR.IRequest<FluentResults.Result<TReturnValue>>
	{
	}
}
