using Microsoft.AspNetCore.Mvc;

namespace Gyak9.Controllers
{
    public class BoatsController : Controller
    {
        [HttpGet]
        [Route("questions/all")]
        public IActionResult M1()
        {
            Models.HajosContext context = new Models.HajosContext();
            var kérdések = from x in context.Questions select x.Question1;
            return new JsonResult(kérdések);
        }
    }
}
