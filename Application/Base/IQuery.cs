using FluentResults;

namespace Application.Base;



public interface IQuery<TResponse> : MediatR.IRequest<Result<TResponse>>
{

}

