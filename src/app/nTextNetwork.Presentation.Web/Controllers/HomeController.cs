using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using nTextNetwork.Core.Impl;
using nTextNetwork.Core.Interfaces;
using nTextNetwork.Presentation.Web.Models;
using nTextNetwork.Presentation.Web.Models.Extensions;
using nTextNetwork.Presentation.Web.Models.LightWeight;
using nTextNetwork.Presentation.Web.Models.Utils;

namespace nTextNetwork.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        private const int CountToSerialize = 50;
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var user = Session["user"] as User;

            if (user == null)
            {
                user = new User();
                Session.Add("user", user);
            }

            return View(user);
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

            ITextStatisticBuilder builder = new TextStatisticsBuilder();
            var stats = builder.Build(file.InputStream);

            LightWeightObject lightWeight = stats.ToLightWeight();

            var user = Session["user"] as User;
            if (user != null)
            {
                AddLightObjToDb(lightWeight, user, file.FileName);
            }

            var words = lightWeight.WordFrequencyDictionary
            .Take(CountToSerialize)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

            var serializer = new JsonSerializerForJit();
            string serrialized = serializer.Serialize(words);

            JsonResult result = Json(serrialized, JsonRequestBehavior.AllowGet);

            return result;
        }

        public JsonResult GetUploadedFileInfoBy(string userId)
        {
            var user = Session["user"] as User;
            if (user != null)
            {
                foreach (var fileName in user.ListFiles)
                {
                    //entityForReturn.FileNames.Add(fileName.FileName);
                }
            }
            return null;
        }

        private JsonResult CreateJsonResult(IDictionary<string, int> words)
        {
            var serializer = new JsonSerializerForJit();
            string serrialized = serializer.Serialize(words);

            JsonResult result = Json(serrialized, JsonRequestBehavior.AllowGet);

            return result;
        }

        private void AddLightObjToDb(LightWeightObject lightObj, User user, string fileName)
        {
            using (Db.Server.RequestStart(Db.Database))
            {
                var collection = Db.Database.GetCollection<LightWeightObject>("lightObjCollection");

                collection.Insert(lightObj);

                user.ListFiles.Add(new UploadedFileInfo(lightObj.Id, fileName));

                Session.Add("user", user);
            }
        }

        private LightWeightObject ReadLightObjFromDb(ObjectId id)
        {
            using (Db.Server.RequestStart(Db.Database))
            {
                var collection = Db.Database.GetCollection<LightWeightObject>("lightObjCollection");
                var query = Query.EQ("_id", id);

                return collection.FindOne(query);
            }
        }

        [HttpGet]
        public JsonResult GetFileById(string fileId)
        {
            LightWeightObject lightWeightObject = ReadLightObjFromDb(ObjectId.Parse(fileId));

            var words = lightWeightObject.WordFrequencyDictionary
           .Take(CountToSerialize)
           .ToDictionary(pair => pair.Key, pair => pair.Value);

            return CreateJsonResult(words);
        }

        //public JsonResult GetPunctuationLiterals(string fileId)
        //{
        //    LightWeightObject lightWeightObject = ReadLightObjFromDb(ObjectId.Parse(fileId));

        //    var words = lightWeightObject.WordProbabilityDictionary.Take(CountToSerialize)
        //        .ToDictionary(pair => pair.Key, pair => pair.Value);

        //    var serializer = new JsonSerializerForJit();
        //    string serrialized = serializer.Serialize(words);

        //    JsonResult result = Json(serrialized, JsonRequestBehavior.AllowGet);

        //    return result;
        //}
    }
}
