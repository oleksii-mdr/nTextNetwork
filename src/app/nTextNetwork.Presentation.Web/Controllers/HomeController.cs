using System.Linq;
using System.Web;
using System.Web.Mvc;
using nTextNetwork.Core.Impl;
using nTextNetwork.Core.Interfaces;
using nTextNetwork.Presentation.Web.Models;

namespace nTextNetwork.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Analyse()
        {
            if (Request.Files.Count == 0)
                return null;

            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength == 0)
                return null;
            int countToSerialize = 50;

            ITextStatisticBuilder builder = new TextStatisticsBuilder();
            var stats = builder.Build(file.InputStream);

            var iterator = stats.WordFrequencyDictionary.Take(countToSerialize);
            var dictionary = iterator.ToDictionary(pair => pair.Key, pair => pair.Value);

            return Json((new JsonSerializerForJit().Serialize(dictionary, countToSerialize)));
        }
    }
}
