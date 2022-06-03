using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Techpork.Infrastructure.Services
{
    public static class FileService
    {
        public static void DeleteFile(string file)
        {
            if (file.IndexOf("%2F") > -1)
                file = file.Replace("%2F", "\\");
#if DEBUG
            var basePath = Path.GetFullPath("../Techpork.Infrastructure/");
#else
            var basePath = Path.GetFullPath("./");
#endif
            var fullPath = basePath + file;
            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }

        public static string Upload(string img, string name, bool isAttachment = false)
        {
            var extension = FileService.GetFileExtension(img);
            if (string.IsNullOrEmpty(extension))
                return img;
            byte[] bytes = Convert.FromBase64String(img);
            MemoryStream str = new MemoryStream(bytes);
            FormFile file = new FormFile(str, 0, bytes.Length, name, name);

            //var file = Request.Form.Files[0];
#if DEBUG
            var pathToSave = Path.GetFullPath($"../Techpork.Infrastructure/Resources/" + (isAttachment ? "Attachments" : "Images"));
#else
            var pathToSave = Path.GetFullPath($"./Resources/" + (isAttachment ? "Attachments" : "Images"));
#endif
            var folderName = Path.Combine("Resources", (isAttachment ? "Attachments" : "Images"));

            if (file.Length > 0)
            {
                var fileName = file.FileName.Trim('"') + "." + extension;
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName).Replace("\\", "/");

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return dbPath;
            }
            else
            {
                return null;
            }
        }

        public static string GetFileExtension(string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "png";
                case "/9J/4":
                    return "jpg";
                case "AAAAF":
                    return "mp4";
                case "JVBER":
                    return "pdf";
                case "AAABA":
                    return "ico";
                case "UMFYI":
                    return "rar";
                case "E1XYD":
                    return "rtf";
                case "U1PKC":
                    return "txt";
                case "MQOWM":
                case "77U/M":
                    return "srt";
                default:
                    return "txt";
            }
        }
    }
}
