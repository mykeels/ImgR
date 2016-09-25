using ImgR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImgR
{
    public class ImagesController: Controller
    {
        [Route("~/images/")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("~/images/devices")]
        public ActionResult Devices()
        {
            return View();
        }

        [Route("~/images/test")]
        public ActionResult Test()
        {
            return View();
        }

        [Route("~/images/add")]
        public ActionResult Add(string Title = null, string Category = null, string Description = null, string ResizeForDevices = null, HttpPostedFileBase Data = null)
        {
            if (Data != null)
            {
                Image temp = Models.Image.AddTemp(Data.InputStream.ToBytes(), Data.FileName.Split('.').Last());
                Session.AddSafe("sessionTempImage", temp);
                ViewData.AddSafe("viewTempImage", temp);
            }
            if (!String.IsNullOrEmpty(Title))
            {
                var sessionImage = (Models.Image)Session["sessionTempImage"];
                if (sessionImage != null)
                {
                    sessionImage.Title = Title;
                    sessionImage.Description = Description;
                    sessionImage.Category = Category;
                    sessionImage.ResizeForDevices = (ResizeForDevices == "on") ? true : false;
                    sessionImage.Active = true;
                    sessionImage.TargetDevice = Image.Device.GetDefault().ID;
                    List<Image> newImages = Image.Add(sessionImage).ToList();
                    Session.Remove("sessionTempImage");
                    return Redirect("~/images/" + sessionImage.Name);
                }
            }
            return View();
        }

        [Route("~/images/devices/add")]
        public ActionResult AddDevice(string Name = null, string ShortName = null, int Width = 0, int Height = 0, int Orientation = 0, string UserAgent = null)
        {
            if (!String.IsNullOrEmpty(Name) &&
                !String.IsNullOrEmpty(ShortName) &&
                Width > 0 &&
                Height > 0)
            {
                try
                {
                    Models.Image.Device.Add(new Models.Image.Device()
                    {
                        Name = Name,
                        Height = Height,
                        Orientation = (Models.Image.Device.DeviceOrientation)Orientation,
                        ShortName = ShortName,
                        UserAgent = UserAgent,
                        Width = Width
                    });
                    ViewData.Add("success-message", "New Image Device Created Successfully");
                }
                catch (Exception ex)
                {
                    Site.LogError(ex);
                    ViewData.Add("error-message", ex.Message);
                }
            }
            return View();
        }

        [Route("~/images/{filename}")]
        public ActionResult Details()
        {
            var fileName = (string)RouteData.Values["filename"];
            var image = Models.Image.GetImage(fileName);
            if (image == null)
            {
                Session.AddSafe("error-message", "Image " + fileName + " Not Found");
                return Redirect("~/images/");
            }
            ViewData.Add("image", image);
            return View();
        }

        [Route("~/images/devices/{short_name}")]
        public ActionResult DeviceDetails()
        {
            string shortName = (string)RouteData.Values["short_name"];
            ViewData.AddSafe("device", Models.Image.Device.GetDevice(shortName));
            return View();
        }

        [Route("~/images/register-screen")]
        public JsonResult Register(int width, int height)
        {
            Response.AddHeader("Access-Control-Allow-Origin", "*");
            if (width > 0 && height > 0)
            {
                Site.Context().Session.AddOnce("screen-size", width + "-" + height);
                return Json(new Response<object>((string)Session["screen-size"], null, true), JsonRequestBehavior.AllowGet);
            }
            return Json(new Response<object>("Invalid Screen Size", null, false), JsonRequestBehavior.AllowGet);
        }

        [Route("~/images/{filename}/edit")]
        public ActionResult Edit(string Name = null, string Title = null, string Category = null, string Description = null, HttpPostedFileBase Data = null)
        {
            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Category))
            {
                try
                {
                    var img = Models.Image.GetImage(Name);
                    if (img != null)
                    {
                        img.Title = Title;
                        img.Description = Description;
                        img.Category = Category;
                        img.CreationTime = DateTime.Now;
                    }
                    if (Data != null)
                    {
                        img.Extension = Data.FileName.Split('.').Last();
                        img.Data = Data.InputStream.ToBytes();
                    }
                    Models.Image.Edit(img);
                    ViewData.AddSafe("success-message", "Image " + Name + " has been updated");
                }
                catch (Exception ex)
                {
                    Site.LogError(ex);
                    ViewData.AddSafe("error-message", ex.Message);
                }
            }

            var fileName = (string)RouteData.Values["filename"];
            var image = Models.Image.GetImage(fileName);
            if (image == null)
            {
                ViewData.AddSafe("error-message", "Image " + fileName + " Not Found");
                return Redirect("~/images/");
            }
            ViewData.AddSafe("image", image);
            if (!String.IsNullOrEmpty(Name)) return Redirect("~/images/" + Name);
            return View();
        }

        [Route("~/images/devices/{short_name}/edit")]
        public ActionResult EditDevice(string Name = null, string ShortName = null, int Width = 0, int Height = 0, int Orientation = 0, string UserAgent = null, string IsDefault = null)
        {
            string shortName = (string)RouteData.Values["short_name"];
            ViewData.AddSafe("device", Models.Image.Device.GetDevice(shortName));
            if (!String.IsNullOrEmpty(Name) &&
                !String.IsNullOrEmpty(ShortName) &&
                Width > 0 &&
                Height > 0)
            {
                try
                {
                    Models.Image.Device.Edit(new Models.Image.Device()
                    {
                        Name = Name,
                        Height = Height,
                        Orientation = (Models.Image.Device.DeviceOrientation)Orientation,
                        ShortName = ShortName,
                        UserAgent = UserAgent,
                        Width = Width,
                        IsDefault = IsDefault == "on" ? true : false
                    });
                    ViewData.Add("success-message", Name + " Edited Successfully");
                }
                catch (Exception ex)
                {
                    Site.LogError(ex);
                    ViewData.Add("error-message", ex.Message);
                }
            }
            return View();
        }

        [Route("~/images/{file_name}.{extension}")]
        public FilePathResult Serve()
        {
            string filename = (string)RouteData.Values["file_name"];
            string extension = (string)RouteData.Values["extension"];
            string screen_size = null;
            if (!String.IsNullOrEmpty((string)Site.Context().Session["screen-size"])) screen_size = (string)Site.Context().Session["screen-size"];
            if (String.IsNullOrEmpty(screen_size) && Request.Cookies["screen-size"] != null) screen_size = Convert.ToString(Request.Cookies["screen-size"].Value);
            if (String.IsNullOrEmpty(screen_size) && Request.Headers["screen-size"] != null) screen_size = Convert.ToString(Request.Headers["screen-size"]);
            var img = Models.Image.GetImage(filename);
            if (img == null) return File(Site.MapPath("~/images/" + filename + "." + extension), "image/" + extension);
            else if (!String.IsNullOrEmpty(screen_size))
            {
                int screenWidth = Convert.ToInt32(screen_size.Split('-').First());
                int screenHeight = Convert.ToInt32(screen_size.Split('-').Last());

                Models.Image.Device defaultImageDevice = Models.Image.Device.GetDevice(img.TargetDevice);
                if (defaultImageDevice == null) defaultImageDevice = Image.Device.GetDefault();

                if (img.ResizeForDevices || (img.ResizeDevice > 0))
                {
                    List<Models.Image> resizes = img.GetResizes();
                    if (img.ResizeOf > 0) resizes = Models.Image.GetImage(img.ResizeOf).GetResizes();
                    List<Models.Image.Device> devices = resizes.Select((imgR) => Models.Image.Device.GetDevice(imgR.ResizeDevice)).ToList();

                    if (screenWidth / defaultImageDevice.Width >= 0.8)
                    {
                        return File(img.URL, "image/" + img.Extension);
                    }
                    else
                    {
                        devices.Sort((dv1, dv2) =>
                        {
                            return dv2.Width.CompareTo(dv1.Width);
                        });
                        for (int i = 0; i < devices.Count; i++)
                        {
                            if (screenWidth / devices[i].Width >= 0.8 || i == devices.Count - 1)
                            {
                                return File(resizes.Where((imgR) => imgR.ResizeDevice == devices[i].ID).FirstOrDefault().URL, "image/" + resizes[i].Extension);
                            }
                        }
                    }

                }
                return File(Site.MapPath(img.URL), "image/" + img.Extension);
            }
            else if (Site.IsMobile())
            {
                List<Models.Image> resizes = img.GetResizes();
                var iphoneImage = (from pp in resizes where pp.ResizeDevice.Equals(3) select pp).FirstOrDefault();
                return File(iphoneImage.URL, "image/" + iphoneImage.Extension);
            }
            else
            {
                return File(Site.MapPath("~/images/" + filename + "." + extension), "image/" + extension);
            }
        }

        [Route("~/images/temp/{file_name}")]
        public FileContentResult ServeTemp()
        {
            string filename = (string)RouteData.Values["file_name"];
            string namePart = filename.Split('.').FirstOrDefault();
            string extension = filename.Split('.').LastOrDefault();
            var img = Models.Image.GetTemp(namePart);
            if (img == null || img.Data == null) return null;
            else
            {
                return File(img.Data, "image/" + img.Extension);
            }
        }

        [Route("~/images/temp/delete")]
        public ActionResult DeleteTemp()
        {
            Session.Remove("sessionTempImage");
            Image.TempImages.Clear();
            return Redirect("~/images/add");
        }
    }
}
