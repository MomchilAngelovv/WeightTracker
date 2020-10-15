namespace WeightTracker.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
                
        public IActionResult Error()
        {
            return this.View();
        }

        public IActionResult NotAllowed()
        {
            return this.View();
        }
    }
}
