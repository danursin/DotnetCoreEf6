using Domain.Services.Interfaces;
using Microsoft.AspNet.Mvc;

namespace WebLibrary.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult All()
        {
            var people = _personService.All();
            return Ok(people);
        }
    }
}
