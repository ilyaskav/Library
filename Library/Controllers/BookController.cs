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
            return View();
        }
    }
}