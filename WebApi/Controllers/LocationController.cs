using Microsoft.AspNetCore.Mvc;

namespace EventTracingBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
