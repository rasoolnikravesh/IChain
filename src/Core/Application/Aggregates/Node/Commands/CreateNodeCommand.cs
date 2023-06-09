namespace Application.Aggregates.Node.Commands;

public record CreateNodeCommand(string Name, string Ip, ushort Port, string AccountAddress) : ICommand
{
	public string Name { get; set; } = Name;

	public string Ip { get; set; } = Ip;

	public ushort Port { get; set; } = Port;

	public string AccountAddress { get; set; } = AccountAddress;
}