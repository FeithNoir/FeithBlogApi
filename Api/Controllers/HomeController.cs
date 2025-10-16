
using Microsoft.AspNetCore.Mvc;

namespace FeithArtistGaller.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Biography()
        {
            return View();
        }

        public IActionResult Portfolio()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Exhibitions()
        {
            return View();
        }
    }
}
