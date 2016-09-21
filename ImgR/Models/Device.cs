using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace ImgR.Models
{
    public partial class Image
    {
        public class Device
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string ShortName { get; set; }
            public string UserAgent { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public DeviceOrientation Orientation { get; set; }
            public bool IsDefault { get; set; }

            public static List<Device> Devices = new List<Device>();
            public enum DeviceOrientation
            {
                Portrait,
                Landscape
            }

            public tbl_ImageDevice Map()
            {
                tbl_ImageDevice ret = new tbl_ImageDevice();
                ret.ID = this.ID;
                ret.Height = this.Height;
                ret.IsDefault = this.IsDefault;
                ret.Name = this.Name;
                ret.Orientation = Convert.ToInt32(this.Orientation);
                ret.ShortName = this.ShortName;
                ret.UserAgent = this.UserAgent;
                ret.Width = this.Width;
                return ret;
            }

            public static Device Map(tbl_ImageDevice img)
            {
                Device ret = new Device();
                ret.Height = img.Height;
                ret.ID = img.ID;
                ret.IsDefault = img.IsDefault;
                ret.Name = img.Name;
                ret.Orientation = (DeviceOrientation)img.Orientation;
                ret.ShortName = img.ShortName;
                ret.UserAgent = img.UserAgent;
                ret.Width = img.Width;
                return ret;
            }

            public static List<Device> Load()
            {
                if (Devices == null || (Devices.Count == 0))
                {
                    using (ImgRDataContext db = new ImgRDataContext())
                    {
                        Devices = db.tbl_ImageDevices.ToList().Select((device) => Map(device)).ToList();
                        return Devices;
                    }
                }
                return Devices;
            }

            public static Device GetDevice(string shortName)
            {
                return (from pp in Load() where pp.ShortName.Equals(shortName) select pp).FirstOrDefault();
            }

            public static Device GetDevice(int ID)
            {
                return (from pp in Load() where pp.ID.Equals(ID) select pp).FirstOrDefault();
            }

            public static bool Exists(Device dv)
            {

                using (ImgRDataContext db = new ImgRDataContext())
                {
                    return (from pp in db.tbl_ImageDevices where pp.ID.Equals(dv.ID) || pp.ShortName.Equals(dv.ShortName) || pp.Height.Equals(dv.Height) && pp.Width.Equals(dv.Width) select pp).Count() > 0 ||
                        (from pp in Devices where pp.Height.Equals(dv.Height) && pp.Width.Equals(dv.Width) select pp).Count() > 0;
                }
            }

            public static void Add(Device dv)
            {
                if (!Exists(dv))
                {
                    using (ImgRDataContext db = new ImgRDataContext())
                    {
                        db.tbl_ImageDevices.InsertOnSubmit(dv.Map());
                        db.SubmitChanges();
                        Devices.Add(dv);
                    }
                }
            }

            private static void removeAllDefault()
            {
                Devices.ForEach((device) => device.IsDefault = false);
                using (ImgRDataContext db = new ImgRDataContext())
                {
                    var query = (from pp in db.tbl_ImageDevices select pp);
                    foreach (var device in query)
                    {
                        device.IsDefault = false;
                    }
                    db.SubmitChanges();
                }
            }

            public static void Edit(Device dv)
            {
                if (Exists(dv))
                {
                    using (ImgRDataContext db = new ImgRDataContext())
                    {
                        var query = (from pp in db.tbl_ImageDevices where pp.ID.Equals(dv.ID) || pp.ShortName.Equals(dv.ShortName) select pp).FirstOrDefault();
                        if (query != null)
                        {
                            query.Width = dv.Width;
                            query.Height = dv.Height;
                            query.UserAgent = dv.UserAgent;
                            query.Orientation = Convert.ToInt32(dv.Orientation);
                            query.Name = dv.Name;
                            query.IsDefault = dv.IsDefault;
                            if (query.IsDefault) removeAllDefault();
                        }
                        db.SubmitChanges();
                    }
                    for (int i = 0; i < Devices.Count; i++)
                    {
                        var device = Devices[i];
                        if (device.ID == dv.ID || device.ShortName.Equals(dv.ShortName))
                        {
                            device = Map(dv.Map());
                        }
                    }
                }
            }

            public static Device GetDefault()
            {
                return (from pp in Devices where pp.IsDefault select pp).FirstOrDefault();
            }

            public float GetScale()
            {
                Device defaultDevice = GetDefault();
                return Math.Min((float)this.Width / (float)defaultDevice.Width, (float)this.Height / (float)defaultDevice.Height);
            }

            public void SetImageScale(ref int Width, ref int Height)
            {
                float scale = this.GetScale();
                if (scale < 1)
                {
                    Width = (int)(Width * scale);
                    Height = (int)(Height * scale);
                }
            }

            public bool IsEligible()
            {
                if (this.GetScale() > 1) return false;
                else return true;
            }

            public string GetOrientation()
            {
                return Orientation == DeviceOrientation.Landscape ? "Landscape" : "Portrait";
            }

            public Bitmap Transform(Bitmap bmp)
            {
                int w = bmp.Width;
                int h = bmp.Height;

                this.SetImageScale(ref w, ref h);
                return BitmapExtensions.Scale(bmp, w, h);
            }

            public static List<Image> GetTransforms(Image img)
            {
                if (img.IsResized() || img.Data == null) return null;
                else
                {
                    List<Image> ret = new List<Image>();
                    Devices.ForEach(dv =>
                    {
                        if (dv.IsEligible() && !dv.IsDefault)
                        {
                            //device size is smaller, then image needs to be resized to fit it
                            Image retimg = (new Image()).Clone();
                            Bitmap bmp = BitmapExtensions.ToBitmap(img.Data);
                            Bitmap retBmp = dv.Transform(bmp);
                            retimg.Data = BitmapExtensions.ToBytes(retBmp);
                            retimg.Width = retBmp.Width;
                            retimg.Height = retBmp.Height;
                            retimg.Name = img.Name + "-" + dv.ShortName;
                            retimg.Extension = img.Extension;
                            retimg.ResizeDevice = dv.ID;
                            retimg.TargetDevice = GetDefault().ID;
                            retimg.URL = retimg.GetFileURL();
                            retimg.CreationTime = DateTime.Now;
                            ret.Add(retimg);
                        }
                    });
                    return ret;
                }
            }
        }
    }
}
