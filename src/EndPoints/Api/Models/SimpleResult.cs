namespace Api.Models;

public class SimpleResult
{
	public bool Status { get; set; }

	public List<string> Messages { get; set; }


}

public class SimpleResult<T> : SimpleResult
{
	public T Data { get; set; }
}