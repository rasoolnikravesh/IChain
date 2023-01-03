namespace NetworkBase;

public interface ITransactionService
{
	Task BroadCast(string message, CancellationToken cancellationToken);
}