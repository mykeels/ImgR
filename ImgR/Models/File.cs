using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ImgR.Models
{
    internal class File
    {
        public static string GetFileName(string path)
        {
            char splitter = '/';
            if (path.Contains(@"\")) splitter = '\\';
            string[] parts = path.Split(splitter);
            return parts.LastOrDefault("");
        }

        public static string GetExtension(string path)
        {
            return path.Split('.').LastOrDefault("file");
        }

        public static string PreventNameClash(string fullPath)
        {
            fullPath = Site.MapPath(fullPath);
            if (System.IO.File.Exists(fullPath))
            {
                string folderPart = GetFolderPart(fullPath);
                string filename = GetFileName(fullPath);
                string newFileName = filename.Split('.').First(filename.Split('.').Count() - 1).Join(".") +
                    "-" + Convert.ToInt32(System.IO.Directory.GetFiles(folderPart).Count((file) =>
                    {
                        file = GetFileName(file);
                        return file.StartsWith(filename.Split('.').First(filename.Split('.').Count() - 1).Join(".").Split('-').FirstOrDefault());
                    }) + 1) + "." +
                    GetExtension(filename);
                return folderPart.Trim('/') + "/" + newFileName;
            }
            return fullPath;
        }

        public static string CreateFolder(string path)
        {
            path = Site.MapPath(path);
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            return path;
        }

        public static string GetFolderPart(string path)
        {
            char splitter = '/';
            if (path.Contains(@"\")) splitter = '\\';
            string[] parts = path.Split(splitter);
            if (System.IO.File.Exists(path)) return parts.First(parts.Count() - 1).Join("/");
            else if (System.IO.Directory.Exists(path)) return path;
            else return parts.First(parts.Count() - 1).Join("/");
        }

        public static string GetFolderPath(string path)
        {
            char ch = '/';
            if (path.Contains(@"\"))
            {
                ch = '\\';
            }
            char[] separator = new char[] { ch };
            string[] myarray = path.Split(separator);
            if (System.IO.File.Exists(path))
            {
                return myarray.First<string>((myarray.Count<string>() - 1)).Join("/");
            }
            if (System.IO.Directory.Exists(path))
            {
                return path;
            }
            return path;
        }
    }
}
