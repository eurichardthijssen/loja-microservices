using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Web.Controllers
{
    public class Product : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
