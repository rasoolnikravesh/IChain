using App.Hubs;
using Application.Aggregates.Transaction.Commands;
using Domain.Aggregates.Transaction;
using Domain.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Persistence;

namespace App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
	public IMediator Mediator { get; }


	public TestController(IMediator mediator)
	{
		Mediator = mediator;
	}

	[HttpGet]
	public async Task<IActionResult> Set(CancellationToken cancellationToken)
	{
		var t = new CreateTransaction("Rasool", "mmd", "Test");

		var result = await Mediator.Send(t, cancellationToken);

		foreach (IDomainEvent domainEvent in result.Value.DomainEvents)
		{
			//await Mediator.Publish(domainEvent, cancellationToken);

		}


		return Ok(result);
	}


}