using System.Web.Mvc;

namespace nText.Presentation.Web.Controllers
{
    public class StagingController : Controller
    {
        //
        // GET: /Staging/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
