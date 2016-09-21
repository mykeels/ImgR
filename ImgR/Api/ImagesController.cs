using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;

namespace ImgR.Api
{
    public class ImagesController: ApiController
    {
        [HttpGet()]
        [Route("~/api/images/categories")]
        public List<string> Categories()
        {
            return Models.Image.GetCategories();
        }

        [HttpGet()]
        [Route("~/api/images/getbycategory")]
        public IEnumerable<Models.Image> GetByCategory(string category, bool onlyActive = true)
        {
            return Models.Image.GetImagesByCategory(category, onlyActive);
        }

        [HttpGet()]
        [Route("~/api/images/all")]
        public IEnumerable<Models.Image> All(bool onlyActive = true, int ownerType = 0, long ownerID = 0)
        {
            return Models.Image.GetImages(onlyActive, ownerType, ownerID);
        }
    }
}
