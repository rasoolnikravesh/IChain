using Application.Aggregates.Node.Queries;
using FluentResults;

namespace Application.Aggregates.Node.QueryHandlers;

public class QueryHandlers : Base.IRequestHandler<GetSelfNodeAliveQuery, string>
{
	
	public async Task<Result<string>> Handle(GetSelfNodeAliveQuery request, CancellationToken cancellationToken)
	{
		return await Task.Run(() =>
		{
			var result = Result.Ok("I'am Alive");
			return result;
		}, cancellationToken);
	}
}