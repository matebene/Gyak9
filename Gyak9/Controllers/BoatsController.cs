using Gyak9.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gyak9.Controllers
{
    public class BoatsController : Controller
    {
        [HttpGet]
        [Route("questions/all")]
        public IActionResult M1()
        {
            HajosContext context = new HajosContext();
            var kérdések = from x in context.Questions select x.Question1;
            return new JsonResult(kérdések);
        }
        [HttpGet]
        [Route("questions/{sorszám}")]
        public  IActionResult M2(int sorszám)
        {
            HajosContext context = new HajosContext();
            var kérdés = (from x in context.Questions where x.QuestionId==sorszám select x).FirstOrDefault();
            if (kérdés == null) return BadRequest("Nincs ilyen sorszám");
            return new JsonResult(kérdés);
        }
    }
}
