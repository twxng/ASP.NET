using Microsoft.AspNetCore.Mvc;
using lr3.Services;

namespace lr3.Controllers{
	[ApiController]
	[Route("[controller]")]

	public class CurrentTimeController : ControllerBase
	{
		private readonly ICurrentTimeCheckerService _currentTimeCheckerService;

		public CurrentTimeController(ICurrentTimeCheckerService currentTimeCheckerService)
		{
			_currentTimeCheckerService = currentTimeCheckerService;
		}

		[HttpGet]
		public IActionResult GetCurrentTime()
		{
			var currentTime = _currentTimeCheckerService.GetCurrentTime();
			return Ok(currentTime);
		}
	}
}
