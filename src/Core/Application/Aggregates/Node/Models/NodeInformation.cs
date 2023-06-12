namespace Application.Aggregates.Node.Models;

public class NodeInformation
{
	public Guid Id { get; set; }

	public string Name { get; set; }

	public string Address { set; get; }

	public int Port { set; get; }

}