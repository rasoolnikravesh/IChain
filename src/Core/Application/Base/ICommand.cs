using FluentResults;

namespace Application.Base;

public interface ICommand : MediatR.IRequest<Result>
{

}

public interface ICommand<T> : MediatR.IRequest<Result<T>>
{

}