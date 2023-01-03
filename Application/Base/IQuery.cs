using FluentResults;

namespace Application.Base;



public interface IQuery<T> : MediatR.IRequest<Result<T>>
{

}