namespace Application.Aggregates.Node.Commands;

public class CreateNodeCommand : ICommand
{
	public string Name { get; set; }

	public Guid Id { get; set; }

	public string Ip { get; set; }

	public int Port { get; set; }

	public string AccountAddress { get; set; }
}