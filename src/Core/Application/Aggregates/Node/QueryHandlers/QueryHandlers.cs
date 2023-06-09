using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Aggregates.Node.Models;
using Application.Aggregates.Node.Queries;
using Application.Base;
using Application.Services;
using FluentResults;
using MediatR;

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