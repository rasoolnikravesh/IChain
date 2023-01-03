using Application.Aggregates.Transaction.Commands;
using Domain.Aggregates.Transaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
	public ISender Sender { get; }


	public TestController(ISender sender)
	{
		Sender = sender;
	}

	[HttpGet]
	public async Task<IActionResult> Set(CancellationToken cancellationToken)
	{
		var t = new CreateTransaction("Rasool", "mmd", "Test");

		var result = await Sender.Send(t, cancellationToken);

		return Ok(result);
	}
}