namespace Api.Models;

public static class SimpleResultExtension
{

	public static SimpleResult ToSimpleResult(this FluentResults.Result result)
	{

		var s = new SimpleResult
		{
			Status = result.IsSuccess,
			Messages = result.Successes.Select(x => x.Message).ToList(),
		};

		s.Messages.AddRange(result.Errors.Select(x=> x.Message));
		return s;
	}

	public static SimpleResult<T> ToSimpleResult<T>(this FluentResults.Result<T> result)
	{

		var s = new SimpleResult<T>
		{
			Status = result.IsSuccess,
			Messages = result.Successes.Select(x => x.Message).ToList(),
			Data = result.Value,
		};

		s.Messages.AddRange(result.Errors.Select(x=> x.Message));
		return s;
	}
}
