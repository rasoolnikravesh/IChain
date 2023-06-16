using Application.Aggregates.Transaction.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Network.Services;

namespace Api.Controllers;

public class TransactionController : ApiControllerBase
{
	public INodeClientService ClientService { get; }

	public TransactionController(ISender sender, IPublisher publisher, INodeClientService clientService) : base(sender, publisher)
	{
		ClientService = clientService;
	}

	[HttpPost]
	public async Task<IActionResult> CreateTransaction(CreateTransactionCommand request)
	{
		var result = await Sender.Send(request);
		if (result.IsFailed)

			return BadRequest(result);
		return Ok(result);
	}
	

}