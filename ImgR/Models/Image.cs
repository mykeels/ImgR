using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace ImgR.Models
{
    public partial class Image
    {
        public static List<Image> TempImages = new List<Image>(); //temp images contains images that are yet to be added to the database but have had their file(s) data uploaded already ... They exist in memory till the user fills information about them
        public long ID { get; set; }
        public long OwnerID { get; set; }
        public int OwnerType { get; set; }
        public string URL { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long ResizeOf { get; set; }
        public long BackupOf { get; set; }
        public DateTime CreationTime { get; set; }
        public int Width;
        public int Height;
        public bool Active { get; set; }
        public bool ResizeForDevices { get; set; }
        public int TargetDevice { get; set; }
        public int ResizeDevice { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] Data { get; set; }

        public Image Map(tbl_Image img)
        {
            this.CreationTime = Convert.ToDateTime(img.CreationTime);
            this.Description = img.Description;
            this.ID = Convert.ToInt64(img.ID);
            this.OwnerID = Convert.ToInt64(img.OwnerID);
            this.OwnerType = Convert.ToInt32(img.OwnerType);
            this.URL = img.URL;
            this.Active = Convert.ToBoolean(img.Active);
            this.Category = img.Category;
            this.Title = img.Title;
            this.BackupOf = img.BackupOf;
            this.Extension = img.Extension;
            this.Height = img.Height;
            this.Name = img.Name;
            this.ResizeForDevices = img.ResizeForDevices;
            this.ResizeOf = img.ResizeOf;
            this.TargetDevice = Convert.ToInt32(img.TargetDevice);
            this.ResizeDevice = Convert.ToInt32(img.ResizeDevice);
            this.Width = img.Width;
            return this;
        }

        public Image Clone()
        {
            return (new Image()).Map(Map(this));
        }

        public static tbl_Image Map(Image img)
        {
            tbl_Image ret = new tbl_Image();
            ret.Active = img.Active;
            ret.Category = img.Category;
            ret.CreationTime = img.CreationTime;
            ret.Description = img.Description;
            ret.ID = img.ID;
            ret.OwnerID = img.OwnerID;
            ret.OwnerType = Convert.ToInt32(img.OwnerType);
            ret.Title = img.Title;
            ret.URL = img.URL;
            ret.BackupOf = img.BackupOf;
            ret.Extension = img.GetExtension();
            ret.Height = img.Height;
            ret.Name = img.Name;
            ret.ResizeForDevices = img.ResizeForDevices;
            ret.ResizeOf = img.ResizeOf;
            ret.TargetDevice = img.TargetDevice;
            ret.ResizeDevice = img.ResizeDevice;
            ret.Width = img.Width;
            if (ret.ResizeDevice <= 0) ret.ResizeDevice = null; //to prevent FOREIGN constraint conflicts
            if (ret.TargetDevice <= 0) ret.TargetDevice = null;
            return ret;
        }

        public static IEnumerable<Image> GetImages(bool onlyActive = true, int ownerType = 0, long ownerID = 0, int startIndex = 0)
        {
            using (ImgRDataContext db = new ImgRDataContext())
            {
                foreach (tbl_Image img in (from pp in db.tbl_Images where (!onlyActive || (Convert.ToBoolean(pp.Active) == true)) && 
                                           (ownerType.Equals(0) || pp.OwnerType == Convert.ToInt32(ownerType)) && (ownerID.Equals(0) || Convert.ToInt64(pp.OwnerID) == ownerID)
                                           select pp).Skip(startIndex).Take(60).ToList())
                {
                    yield return (new Image()).Map(img);
                }
            }
        }

        public static IEnumerable<Image> GetImagesByCategory(string category, bool onlyActive = true, int ownerType = 0, long ownerID = 0, int startIndex = 0)
        {
            using (ImgRDataContext db = new ImgRDataContext())
            {
                foreach(tbl_Image img in (from pp in db.tbl_Images where pp.Category.Equals(category) && (!onlyActive || (Convert.ToBoolean(pp.Active) == true))
                                           && (ownerType.Equals(0) || pp.OwnerType == Convert.ToInt32(ownerType)) && (ownerID.Equals(0) || Convert.ToInt64(pp.OwnerID) == ownerID)
                                          select pp).Skip(startIndex).Take(60).ToList())
                {
                    Image ret = (new Image()).Map(img);
                    yield return ret;
                }
            }
        }

        public static Image AddTemp(byte[] Data, string extension, string filename = null)
        {
            try
            {
                Bitmap bmp = Data.ToBitmap(); //Test that byte array is of an Image, and not some mischievous file
                Image ret = new Image();
                if (!String.IsNullOrEmpty(extension)) extension = extension.ToLower();
                else extension = "jpg";
                ret.Extension = extension.ToLower();
                ret.Data = Data;
                if (!String.IsNullOrEmpty(filename)) ret.Name = filename;
                else ret.Name = CreateImageName();
                ret.CreationTime = DateTime.Now;
                ret.Width = bmp.Width;
                ret.Height = bmp.Height;
                ret.URL = "~/images/temp/" + ret.Name + "." + ret.Extension;
                ret.Active = true;
                TempImages.Add(ret);
                return ret;
            }
            catch (Exception ex)
            {
                Site.LogError(ex);
                return null;
            }
        }

        public static Image GetTemp(string Name)
        {
            return (from pp in TempImages where pp.Name.Equals(Name) select pp).FirstOrDefault();
        }

        public string GetRootUrl()
        {
            return String.IsNullOrEmpty(Site.AppSettings("imgr-root-path")) ? "~/uploads/images/" : Site.AppSettings("imgr-root-path");
        }

        public string GetThumbUrl()
        {
            return this.GetRootUrl() + this.Name + "-thumb." + this.Extension;
        }

        public static void Backup(Image img)
        {
            Image newImage = null;
            string newUrl = File.PreventNameClash(img.URL).Replace(Site.MapPath("~/").Replace(@"\", "/"), "~/");
            string newName = File.GetFileName(newUrl).Split('.').FirstOrDefault();
            newImage = GetImage(img.Name);
            if (newImage != null)
            {
                newImage.GetResizes().ForEach((imgT) =>
                {
                    Backup(imgT);
                });
                newImage.Active = false;
                newImage.BackupOf = newImage.ID + 0;
                newImage.ID = 0;
                newImage.Name = newName;
                newImage.URL = newUrl;
                System.IO.File.Copy(Site.MapPath(img.URL), Site.MapPath(newUrl));
                System.IO.File.Copy(Site.MapPath(img.GetThumbUrl()), Site.MapPath(newImage.GetThumbUrl()));
                using (ImgRDataContext db = new ImgRDataContext())
                {
                    var query = (from pp in db.tbl_Images where pp.Name.Equals(img.Name) select pp).FirstOrDefault();
                    if (query != null)
                    {
                        query.Name = newImage.Name;
                        query.URL = newImage.URL;
                        query.BackupOf = img.ID;
                        query.Active = false;
                    }
                    db.SubmitChanges();
                }
            }
        }

        public List<Image> SaveTransforms()
        {
            var transforms = Image.Device.GetTransforms(this);
            transforms.ForEach((imgT) =>
            {
                try
                {
                    imgT.Active = true;
                    imgT.Title = this.Title;
                    imgT.Description = this.Description;
                    imgT.Category = this.Category;
                    imgT.ResizeOf = this.ID;
                    if (imgT.Width > 160)
                    {
                        imgT.Data.ToBitmap().Save(Site.MapPath(imgT.URL), imgT.GetImageFormat());
                        if (imgT.Width > 200)
                        {
                            imgT.Data.ToBitmap().Scale(160).Save(Site.MapPath(imgT.GetThumbUrl()), GetImageFormat(imgT.Extension));
                        }
                        AddToDatabase(imgT);
                    }
                }
                catch (Exception ex)
                {
                    Site.LogError(ex);
                }
            });
            return transforms;
        }

        public static void Edit(Image img)
        {
            if (img.Data != null)
            {
                var oldImg = GetImage(img.Name);
                bool doOldImgResize = oldImg.GetResizes().Count > 0;
                Backup(img);
                img.ID = 0;
                long newImgID = AddToDatabase(img);
                img.Data.ToBitmap().Save(Site.MapPath(img.GetRootUrl() + img.Name + "." + img.Extension), GetImageFormat(img.Extension));
                img.Data.ToBitmap().Scale(160).Save(Site.MapPath(img.GetThumbUrl()), GetImageFormat(img.Extension));
                if (doOldImgResize)
                {
                    img.ID = newImgID;
                    img.SaveTransforms();
                }
            }
            else
            {
                using (ImgRDataContext db = new ImgRDataContext())
                {
                    var query = (from pp in db.tbl_Images where pp.ID.Equals(img.ID) || pp.Name.Equals(img.Name) select pp).FirstOrDefault();
                    if (query != null)
                    {
                        query.Title = img.Title;
                        query.Category = img.Category;
                        query.Description = img.Description;
                        if (img.Data != null)
                        {
                            Bitmap bmp = img.Data.ToBitmap();
                            query.Width = bmp.Width;
                            query.Height = bmp.Height;

                        }
                        db.SubmitChanges();
                    }
                }
            }
        }

        public static IEnumerable<Image> Add(Image img)
        {
            if (img.ID == 0)
            {
                if (String.IsNullOrEmpty(img.Name) || NameExists(img.Name)) img.Name = CreateImageName();
                img.Extension = "jpg";
                bool willReplaceExistingImage = false;
                Image newImage = null;
                img.URL = img.GetFileURL();
                if (img.Data != null)
                {
                    //save the image
                    if (System.IO.File.Exists(Site.MapPath(img.URL)))
                    {
                        // create and save a backup of the original image if exists
                        willReplaceExistingImage = true;
                        string newUrl = File.PreventNameClash(img.URL).Replace(Site.MapPath("~/"), "~/");
                        string newName = File.GetFileName(newUrl).Split('.').FirstOrDefault();
                        System.IO.File.Copy(Site.MapPath(img.URL), Site.MapPath(newUrl));
                        newImage = GetImage(img.Name);
                        if (newImage != null)
                        {
                            newImage.Active = false;
                            newImage.BackupOf = newImage.ID + 0;
                            newImage.ID = 0;
                            newImage.Name = newName;
                            newImage.URL = newUrl;
                        }
                    }
                    img.Data.ToBitmap().Save(Site.MapPath(img.URL), GetImageFormat(img.Extension));
                    if (img.Data != null) img.Data.ToBitmap().Scale(160).Save(Site.MapPath(img.GetThumbUrl()), GetImageFormat(img.Extension));
                    img.CreationTime = DateTime.Now;
                    img.ID = AddToDatabase(img);
                    yield return img;
                    if (img.ResizeForDevices)
                    {
                        foreach (var imgT in img.SaveTransforms())
                        {
                            yield return imgT;
                        }
                    }
                    if (willReplaceExistingImage)
                    {
                        using (ImgRDataContext db = new ImgRDataContext())
                        {
                            var query = (from pp in db.tbl_Images where pp.Name.Equals(img.Name) select pp).FirstOrDefault();
                            if (query != null)
                            {
                                query.Name = newImage.Name;
                                query.URL = newImage.URL;
                                query.BackupOf = img.ID;
                                query.Active = false;
                            }
                            db.SubmitChanges();
                        }
                    }
                }
            }
        }

        public static List<string> GetCategories()
        {
            using (ImgRDataContext db = new ImgRDataContext())
            {
                return (from pp in db.tbl_Images select pp.Category).Distinct().OrderBy((str) => str).ToList();
            }
        }

        private static long AddToDatabase(Image img)
        {
            using (ImgRDataContext db = new ImgRDataContext())
            {
                db.tbl_Images.InsertOnSubmit(Image.Map(img));
                db.SubmitChanges();
            }
            return GetImage(img.Name).ID;
        }

        public static Image GetImage(string Name)
        {
            Image ret = new Image();
            using (ImgRDataContext db = new ImgRDataContext())
            {
                var query = (from pp in db.tbl_Images where pp.Name.Equals(Name) select pp).ToList().LastOrDefault();
                if (query != null) return ret.Map(query);
            }
            return null;
        }

        public static Image GetImage(long ID)
        {
            Image ret = new Image();
            using (ImgRDataContext db = new ImgRDataContext())
            {
                var query = (from pp in db.tbl_Images where pp.ID.Equals(ID) select pp).ToList().LastOrDefault();
                if (query != null) return ret.Map(query);
            }
            return null;
        }

        public List<Image> GetResizes()
        {
            List<Image> ret = new List<Image>();
            using (ImgRDataContext db = new ImgRDataContext())
            {
                var query = (from pp in db.tbl_Images where pp.ResizeOf.Equals(this.ID) select pp).ToList();
                return query.Select(img => (new Image()).Map(img)).ToList();
            }
        }

        public Device GetDevice()
        {
            var device = Device.GetDevice(this.ResizeDevice);
            if (device != null) return device;
            else return Device.GetDefault();
        }

        public bool IsResized()
        {
            return this.ResizeOf > 0;
        }

        public bool IsBackup()
        {
            return this.BackupOf > 0;
        }

        public bool IsOriginal()
        {
            return this.BackupOf <= 0;
        }

        public string GetExtension()
        {
            if (String.IsNullOrEmpty(this.URL)) return "";
            else
            {
                this.Extension = this.URL.Split('.').Last();
                return this.Extension;
            }
        }

        public string GetFileURL()
        {
            return this.GetRootUrl() + this.Name + "." + this.Extension;
        }

        public static string CreateImageName()
        {
            retryImageName:
            string ret = StringX.RandomLetters(12).ToLower();
            if (NameExists(ret) || NameExistsInTemp(ret)) goto retryImageName;
            return ret;
        }

        private static bool NameExists(string name)
        {
            using (ImgRDataContext db = new ImgRDataContext())
            {
                return ((from pp in db.tbl_Images where pp.Name.Equals(name) select pp.Name).Count() > 0);
            }
        }

        private static bool NameExistsInTemp(string name)
        {
            return ((from pp in TempImages where pp.Name.Equals(name) select pp.Name).Count() > 0);
        }

        public System.Drawing.Imaging.ImageFormat GetImageFormat()
        {
            return GetImageFormat(this.Extension);
        }

        public static System.Drawing.Imaging.ImageFormat GetImageFormat(string extension)
        {
            if (String.IsNullOrEmpty(extension)) return System.Drawing.Imaging.ImageFormat.Bmp;
            else
            {
                extension = extension.ToLower();
                switch (extension)
                {
                    case "bmp":
                        return System.Drawing.Imaging.ImageFormat.Bmp;
                    case "emf":
                        return System.Drawing.Imaging.ImageFormat.Emf;
                    case "exif":
                        return System.Drawing.Imaging.ImageFormat.Exif;
                    case "git":
                        return System.Drawing.Imaging.ImageFormat.Gif;
                    case "icon":
                        return System.Drawing.Imaging.ImageFormat.Icon;
                    case "jpeg":
                    case "jpg":
                        return System.Drawing.Imaging.ImageFormat.Jpeg;
                    case "png":
                        return System.Drawing.Imaging.ImageFormat.Png;
                    case "tiff":
                        return System.Drawing.Imaging.ImageFormat.Tiff;
                    case "wmf":
                        return System.Drawing.Imaging.ImageFormat.Wmf;
                    default:
                        return System.Drawing.Imaging.ImageFormat.Bmp;
                }
            }
        }
    }
}
