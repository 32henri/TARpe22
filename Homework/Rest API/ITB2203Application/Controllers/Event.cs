using Microsoft.AspNetCore.Mvc;

namespace ITB2203Application.Controllers
{
    public class Event : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
