//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using Application.Aggregates.Node.Models;
//using Application.Aggregates.Node.Queries;
//using Application.Base;
//using Application.Services;
//using FluentResults;
//using MediatR;

//namespace Application.Aggregates.Node.QueryHandlers;

//public class GetNodesFromSettingQueryHandler : Base.IRequestHandler<GetNodesFromSettingQuery, List<NodeInformation>>
//{
//	public IAppService AppService { get; }


//	public GetNodesFromSettingQueryHandler(IAppService appService)
//	{
//		AppService = appService;
//	}

//	public async Task<Result<List<NodeInformation>>> Handle(GetNodesFromSettingQuery request, CancellationToken cancellationToken)
//	{
//		try
//		{

//			var file = await File.ReadAllTextAsync(AppService.GetAppLocationPath() + "/configs/comunication.json", cancellationToken);

//			var result = JsonSerializer.Deserialize<List<NodeInformation>>(file);
//			return result == null && !result.Any() ? Result.Fail("File Not Found") : Result.Ok(result).ToResult();
//		}
//		catch (Exception e)
//		{
//			Console.WriteLine(e);
//			throw;
//		}
//	}
//}