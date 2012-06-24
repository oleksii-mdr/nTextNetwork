﻿using System.Linq;
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
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                ITextStatisticBuilder builder = new TextStatisticsBuilder();
                var stats = builder.Build(file.InputStream);

                var iterator = stats.WordFrequencyDictionary.Take(50);
                var dictionary = iterator.ToDictionary(pair => pair.Key, pair => pair.Value);

                ViewData["json"] = new JsonSerializerForJit().Serialize(dictionary);
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}
