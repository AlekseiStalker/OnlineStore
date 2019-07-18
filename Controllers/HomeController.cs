using Microsoft.AspNetCore.Mvc; 

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {    
        public IActionResult Index()
        {
            return View();
        } 
    }
}
