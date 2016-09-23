using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ImgR.Models;

namespace ImgR.Api
{
    public class ImagesController: ApiController
    {
        [HttpGet()]
        [Route("~/api/images/categories")]
        public List<string> Categories()
        {
            return Image.GetCategories();
        }

        [HttpGet()]
        [Route("~/api/images/categories/{category}")]
        public IEnumerable<Image> GetByCategory(bool onlyActive = true, int ownerType = 0, long ownerID = 0)
        {
            IHttpRouteData RouteData = Request.GetRouteData();
            string category = Convert.ToString(RouteData.Values["category"]);
            return Image.GetImagesByCategory(category, onlyActive);
        }

        [HttpGet()]
        [Route("~/api/images")]
        public IEnumerable<Image> All(bool onlyActive = true, int ownerType = 0, long ownerID = 0)
        {
            return Image.GetImages(onlyActive, ownerType, ownerID);
        }

        [HttpGet()]
        [Route("~/api/images/{id}")]
        public Response<Image> GetImage()
        {
            IHttpRouteData RouteData = Request.GetRouteData();
            string filename = Convert.ToString(RouteData.Values["id"]);
            long imgId = 0;
            if (!String.IsNullOrEmpty(filename)) return new Response<Image>(filename, Image.GetImage(filename), true);
            else if (Int64.TryParse(filename, out imgId)) return new Response<Image>(filename, Image.GetImage(Convert.ToInt64(filename)), true);
            else return new Response<Image>("Invalid Image ID", null, false);
        }

        [HttpPost()]
        [Route("~/api/images/add")]
        public Response<Image> Add()
        {
            var httpRequest = System.Web.HttpContext.Current.Request;
            if (httpRequest == null)
            {
                System.Web.HttpContext.Current.Response.StatusCode = 400;
                return new Response<Image>("HttpRequest should not be NULL", null, false);
            }
            if (httpRequest.Files.Count > 0)
            {
                foreach (System.Web.HttpPostedFileBase file in httpRequest.Files)
                {
                    return new Response<Image>("New Temp Image Created", Image.AddTemp(file.InputStream.ToBytes(), file.FileName.Split('.').Last()), true);
                }
            }
            System.Web.HttpContext.Current.Response.StatusCode = 406;
            return new Response<Image>("HttpRequest contains no files", null, false);
        }

        [HttpPost]
        [Route("~/api/images/add/confirm")]
        public Response<IEnumerable<Image>> AddConfirm([FromBody()] Image values)
        {
            if (values != null)
            {
                var ret = Image.Add(values);
                if (ret.IsEmpty())
                {
                    System.Web.HttpContext.Current.Response.StatusCode = 501;
                    return new Response<IEnumerable<Image>>("Failed To Add Image", ret, false);
                }
                else
                {
                    return new Response<IEnumerable<Image>>(ret.FirstOrDefault().Name, ret, true);
                }
            }
            System.Web.HttpContext.Current.Response.StatusCode = 400;
            return new Response<IEnumerable<Image>>("Request Values should not be NULL", null, false);
        }
    }
}
