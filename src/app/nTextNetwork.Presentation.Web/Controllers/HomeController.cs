using System.Linq;
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

            var file = Request.Files[0];
            if (file == null)
                return null;
            if (file.ContentLength == 0)
                    return null;
            const int countToSerialize = 50;

            ITextStatisticBuilder builder = new TextStatisticsBuilder();
            var stats = builder.Build(file.InputStream);

            var words = stats.WordFrequencyDictionary
                .Take(countToSerialize)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            var serializer = new JsonSerializerForJit();
            string serrialized = serializer.Serialize(words, countToSerialize);
            return Json(serrialized);
        }
    }
}
