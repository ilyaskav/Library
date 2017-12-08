using Business;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
    }
}