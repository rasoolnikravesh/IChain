namespace Application.Base;

public interface IQuery : MediatR.IRequest
{


}

public interface IQuery<T> : MediatR.IRequest<T>
{

}