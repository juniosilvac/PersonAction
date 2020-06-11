using Microsoft.AspNetCore.Mvc;
using PersonAction.Model;
using PersonAction.Business;

namespace PersonAction.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonsController : ControllerBase
    {
        private IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }
        // GET: api/Persons
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST: api/Persons
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT: api/Persons/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();

            var updatePerson = _personBusiness.Update(person);

            if (updatePerson == null) return BadRequest();

            return new ObjectResult(updatePerson);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NotFound();
        }
    }
}
