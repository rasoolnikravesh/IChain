using Domain.Aggregates.Transaction;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
	public ICommandUnitOfWork CommandUnitOfWork { get; }
	public IQueryUnitOfWork QueryUnitOfWork { get; }


	public TestController(ICommandUnitOfWork commandUnitOfWork, IQueryUnitOfWork queryUnitOfWork)
	{
		CommandUnitOfWork = commandUnitOfWork;
		QueryUnitOfWork = queryUnitOfWork;
	}

	[HttpGet]
	public async Task<IActionResult> Set(CancellationToken cancellationToken)
	{
		//var t = new Transaction("Rasool", "mmd", "Test");

		//var result = await CommandUnitOfWork.GetCommandRepository<Transaction>().AddAsync(t, cancellationToken);
		//return Ok();

		var result = await QueryUnitOfWork.GetQueryRepository<Transaction>().GetAllAsync(cancellationToken);

		return Ok(result);
	}
}