using System.Web.Mvc;
using nTextNetwork.Presentation.Web.Models;

namespace nTextNetwork.Presentation.Web.Controllers
{
    public class DbController : Controller
    {
        //
        // GET: /db/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /db/ping
        public ActionResult Ping()
        {
            Db.Ping();
            //if here all went good
            return View("Index");
        }
        
    }
}