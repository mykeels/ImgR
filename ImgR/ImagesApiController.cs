using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ImgR.Models;

namespace ImgR
{
    public class ImagesApiController : ApiController
    {
        [HttpGet()]
        [Route("~/api/images/categories")]
        public List<string> Categories()
        {
            System.Web.HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            return Image.GetCategories();
        }

        [HttpGet()]
        [Route("~/api/images/categories/{category}")]
        public IEnumerable<Image> GetByCategory(bool onlyActive = true, int ownerType = 0, long ownerID = 0)
        {
            System.Web.HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            IHttpRouteData RouteData = Request.GetRouteData();
            string category = Convert.ToString(RouteData.Values["category"]);
            return Image.GetImagesByCategory(category, onlyActive);
        }

        [HttpGet()]
        [Route("~/api/images")]
        public IEnumerable<Image> All(bool onlyActive = true, int ownerType = 0, long ownerID = 0)
        {
            System.Web.HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            return Image.GetImages(onlyActive, ownerType, ownerID);
        }

        [HttpGet()]
        [Route("~/api/images/{id}")]
        public Response<Image> GetImage()
        {
            System.Web.HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            IHttpRouteData RouteData = Request.GetRouteData();
            string filename = Convert.ToString(RouteData.Values["id"]);
            long imgId = 0;
            if (!String.IsNullOrEmpty(filename)) return new Response<Image>(filename, Image.GetImage(filename), true);
            else if (Int64.TryParse(filename, out imgId)) return new Response<Image>(filename, Image.GetImage(Convert.ToInt64(filename)), true);
            else return new Response<Image>("Invalid Image ID", null, false);
        }

        [HttpPost()]
        [Route("~/api/images/add")]
        public Response<Image> Add([FromBody()] Image values)
        {
            System.Web.HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            if (values != null)
            {
                if (!String.IsNullOrEmpty(values.URL))
                {
                    if (values.URL.StartsWith("http://") || values.URL.StartsWith("https://") || values.URL.StartsWith("//"))
                    {
                        try
                        {
                            System.Drawing.Bitmap image = Api.GetImage(values.URL);
                            Image temp = Image.AddTemp(image.ToBytes(), values.URL.Split('.').Last(), values.Name);
                            return new Response<Image>("New Temp Image Created", temp, true);
                        }
                        catch (Exception ex)
                        {
                            System.Web.HttpContext.Current.Response.StatusCode = 500;
                            return new Response<Image>("Error: " + ex.Message, values, false);
                        }
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Response.StatusCode = 406;
                        return new Response<Image>("Invalid Image URL", null, false);
                    }
                }
                else
                {
                    System.Web.HttpContext.Current.Response.StatusCode = 406;
                    return new Response<Image>("Invalid Image URL", null, false);
                }
            }
            else
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
        }

        [HttpPost]
        [Route("~/api/images/add/confirm")]
        public Response<IEnumerable<Image>> AddConfirm([FromBody()] Image values)
        {
            System.Web.HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            if (values != null)
            {
                Image temp = Image.GetTemp(values.Name);
                Image.TempImages.Remove((from pp in Image.TempImages where pp.Name.Equals(values.Name) select pp).FirstOrDefault());
                if (temp != null)
                {
                    temp.Active = true;
                    temp.Category = values.Category;
                    temp.CreationTime = DateTime.Now;
                    temp.Description = values.Description;
                    temp.OwnerID = values.OwnerID;
                    temp.OwnerType = values.OwnerType;
                    temp.ResizeForDevices = values.ResizeForDevices;
                    temp.TargetDevice = values.TargetDevice;
                    temp.Title = values.Title;
                    var ret = Image.Add(temp).ToList();
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
                else
                {

                }
            }
            System.Web.HttpContext.Current.Response.StatusCode = 400;
            return new Response<IEnumerable<Image>>("Request Values should not be NULL", null, false);
        }

        [HttpGet()]
        [Route("~/api/images/devices")]
        public Response<List<Image.Device>> GetDevices()
        {
            return new Response<List<Image.Device>>("Image Devices", Image.Device.Load(true), true);
        }
    }
}
