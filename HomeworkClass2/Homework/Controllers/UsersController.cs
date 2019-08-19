using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Homework.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
		public static List<User> Users = new List<User>()
		{
			new User("Dragana","Shishkovska",20),
			new User("Petar","Donevski",32),
			new User("Goran","Todorovski",28),
			new User("Martin","Petrovski",25),
			new User("Dario","Kostov",25),
			new User("Viktor","Mijalcev",28),
			new User("Jovana","Shishkovska",16)

		};

		[HttpGet]
		public ActionResult<List<User>> Get()
		{
			return Users;
		}

		[HttpGet("{id}")]
		public ActionResult<User> GetUser(int id)
		{
			try
			{
				if (Users[id-1].Age<18)
				{
					return NotFound($"This user is under age");
				}
					return Users[id - 1];
			}
			catch (IndexOutOfRangeException)
			{

				return NotFound($"The User with {id} id is not found");
			}
			catch(Exception ex)
			{
				return BadRequest($"BROKEN: {ex.Message}");
			}
		}
		[HttpPost]
		public IActionResult Post()
		{
			string body;
			using (StreamReader sr = new StreamReader(Request.Body))
			{
				body = sr.ReadToEnd();
			}
			User user = JsonConvert.DeserializeObject<User>(body);
			Users.Add(user);
			return Ok($"User with id {Users.Count} added!");
		}

		
	}
}