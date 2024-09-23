using System;

namespace lr3.Services
{
	public interface ICurrentTimeCheckerService
	{
		string GetCurrentTime();
	}

	public class CurrentTimeCheckerService : ICurrentTimeCheckerService{
		public string GetCurrentTime(){
			var currentTime = DateTime.Now.Hour;

			return currentTime switch{
				>= 12 and <= 18 => "зараз день",
				>= 18 and <= 23 => "зараз вечір",
				>= 0 and <= 5 => "зараз ніч",
				>= 6 and <= 11 => "зараз ранок",
				_ => "час видалити доту"
			};
		}
	}
}