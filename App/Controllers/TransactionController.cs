using Application.Aggregates.Transaction.Commands;
using Domain.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
	public IMediator Mediator { get; }

	public TransactionController(IMediator mediator)
	{
		Mediator = mediator;
	}

	[HttpPost]
	public async Task<IActionResult> CreateTransaction(CreateTransaction transaction, CancellationToken cancellationToken)
	{
		var result = await Mediator.Send(transaction, cancellationToken);

		if (result.IsSuccess)
		{
			foreach (IDomainEvent domainEvent in result.Value.DomainEvents)
			{
				await Mediator.Publish(domainEvent, cancellationToken);
			}
		}

		return Ok(result);
	}
}