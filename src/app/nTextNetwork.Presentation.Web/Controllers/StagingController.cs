using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nTextNetwork.Core.Impl;
using nTextNetwork.Core.Interfaces;

namespace nTextNetwork.Presentation.Web.Controllers
{
    public class StagingController : Controller
    {
        //
        // GET: /Index/Ye
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                ITextStatisticBuilder builder = new TextStatisticsBuilder();
                var stats = builder.Build(file.InputStream);

                var iterator = stats.WordFrequencyDictionary.Take(50);
                var dictionary = iterator.ToDictionary(pair => pair.Key, pair => pair.Value);

                ViewData["json"] = new JsonSerrializer<Dictionary<string, int>>().SerializeForJit(dictionary);
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}
