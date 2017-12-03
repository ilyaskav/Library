using Business;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private BookManager _bookManager = null;

        public BookController()
        {
            _bookManager = new BookManager();
        }

        // GET: Book
        public ActionResult Index()
        {
            var books = _bookManager.Get();
            return View(books);
        }
    }
}