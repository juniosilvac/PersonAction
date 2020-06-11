using Microsoft.AspNetCore.Mvc;
using PersonAction.Business;
using PersonAction.Model.Context;

namespace PersonAction.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : Controller
    {
        private IBookBusiness _bookBusiness;

        public BooksController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }
        // GET: api/Persons
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST: api/Persons
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(_bookBusiness.Create(book));
        }

        // PUT: api/Persons/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null) return BadRequest();

            var updateBook = _bookBusiness.Update(book);

            if (updateBook == null) return BadRequest();

            return new ObjectResult(updateBook);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookBusiness.Delete(id);
            return NotFound();
        }
    }
}