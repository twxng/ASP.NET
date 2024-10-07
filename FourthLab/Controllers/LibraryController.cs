using FourthLab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FourthLab.Controllers
{
	[Route("Library")]
	[ApiController]
	public class LibraryController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetGreeting()
		{
			return Ok("Welcome to the library");
		}

		// Library/Books
		[HttpGet("Books")]
		public IActionResult GetBooks()
		{
			var books = System.IO.File.ReadAllText("books.json");
			return Ok(JsonConvert.DeserializeObject<List<Book>>(books));
		}

		// Library/Profile/{id?}
		[HttpGet("Profile/{id?}")]
		public IActionResult GetProfile(int? id)
		{
			var users = System.IO.File.ReadAllText("users.json");
			var userList = JsonConvert.DeserializeObject<List<User>>(users);

			if (id.HasValue && id >= 0 && id <= 5)
			{
				// return user info == id
				var user = userList.Find(u => u.Id == id.Value);
				if (user != null)
				{
					return Ok(user);
				}
				return NotFound("User with this id was not found");
			}
			else
			{
				// return user info (first user)
				return Ok(userList[0]);
			}
		}
	}

	public class Book
	{
		public string Title { get; set; }
		public string Author { get; set; }
		public int Year { get; set; }
	}

	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Nickname { get; set; }

		public string Email { get; set; }
	}
}
