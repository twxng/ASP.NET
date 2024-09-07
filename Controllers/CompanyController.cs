using Microsoft.AspNetCore.Mvc;

public class CompanyController : Controller
{
	public IActionResult Info()
	{
		// Task1
		// var company = new Company("Roshen", "JSC", "Ukraine, Kiev, Nauki Avenue 1", "(044) 3517100", "konditer@roshen.com"); ///Joint Stock Company 
		
		// return Json(company);

		// Task2
		Random random = new Random();
		int randomNumber = random.Next(0, 101);

		return Json(new{ RandomNumber = randomNumber });
	}
}