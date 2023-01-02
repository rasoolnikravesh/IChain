namespace Application.Base;

public interface ICommand : MediatR.IRequest
{

}

public interface ICommand<out T> : MediatR.IRequest<T>
{

}