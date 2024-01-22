using Microsoft.AspNetCore.Mvc;
using Swapi.Core.Entities;
using Swapi.Server.Services;

namespace Swapi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public IActionResult GetPerson()
        {
            var person = _peopleService.GetPerson();
            if (person == null)
            {
                return NotFound("Person not found.");
            }

            return Ok(person);
        }
    }
}
