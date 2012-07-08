using System;
using System.Collections.Generic;
using nTextNetwork.Presentation.Web.Models.LightWeight;

namespace nTextNetwork.Presentation.Web.Models
{
    public class User
    {
        public User()
        {
            ListFiles = new List<UploadedFileInfo>();
            UserId = Guid.NewGuid();
        }

        public Guid UserId { set; get; }
        public List<UploadedFileInfo> ListFiles { set; get; }
    }
}