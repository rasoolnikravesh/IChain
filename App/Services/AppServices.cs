using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services;

public class AppService : IAppService
{
	private readonly IWebHostEnvironment _environment;

	public AppService(IWebHostEnvironment environment)
	{
		_environment = environment;
	}
	public string GetAppLocationPath()
	{
		return _environment.WebRootPath;
			
	}
}