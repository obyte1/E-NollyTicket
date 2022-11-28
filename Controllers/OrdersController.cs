using Microsoft.AspNetCore.Mvc;

namespace NollyTickets.Ng.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
