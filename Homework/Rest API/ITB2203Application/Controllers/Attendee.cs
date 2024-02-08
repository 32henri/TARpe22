using Microsoft.AspNetCore.Mvc;

namespace ITB2203Application.Controllers
{
    public class Attendee : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
