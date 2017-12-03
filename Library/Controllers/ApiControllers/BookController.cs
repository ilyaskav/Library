using Business;
using Business.ViewModels;
using System.Web.Http;

namespace Library.Controllers.ApiControllers
{
    public class BookController : ApiController
    {
        private BookManager _bookManager = null;

        public BookController()
        {
            _bookManager = new BookManager();
        }

        public IHttpActionResult Get()
        {
            var books = _bookManager.Get();

            return Ok(books);
        }

        public IHttpActionResult Post (BookModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool isCreated = _bookManager.CreateBook(model);

            return Ok(isCreated);
        }
    }
}
