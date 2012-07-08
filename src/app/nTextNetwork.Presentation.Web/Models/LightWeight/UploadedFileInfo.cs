using MongoDB.Bson;

namespace nTextNetwork.Presentation.Web.Models.LightWeight
{
    /// <summary>
    /// Strores information about user uploaded files.
    /// </summary>
    public class UploadedFileInfo
    {
        public ObjectId FileId { private set; get; }
        public string FileName { private set; get; }

        public UploadedFileInfo(ObjectId fileId, string fileName)
        {
            FileId = fileId;
            FileName = fileName;
        }
    }
}