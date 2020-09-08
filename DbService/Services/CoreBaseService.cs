using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DbServices.Base;
using DbServices.Model;
using Interfaces.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DbServices.Services
{
    public class CoreBaseService : BaseService, ICoreBase
    {
        private readonly SoomDbContext _context;

        public CoreBaseService(SoomDbContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public string GenerateRandomCode()
        {
            int length = 7;

            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }

            return str_build.ToString().ToLower();
        }

        public string GenerateRandomCodeAsNumber()
        {
            Random rnd = new Random();
            int _min = 1000;
            int _max = 9999;
            int month = rnd.Next(_min, _max);

            return month.ToString();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool SaveMultiImage(string root, List<string> imgs, out List<string> filesName)
        {
            var tempFileNames = new List<string>();
            foreach(var img in imgs)
            {
                var fileaName = "";
                var extention = "";

                var fileExtention = img.Substring(0, 5).ToUpper();

                if (fileExtention == "IVBOR")
                    extention = ".png";
                
                if (fileExtention == "/9J/4")
                    extention = ".jpg";

                if (fileExtention == "JVBER")
                    extention = ".pdf";
                
                if(string.IsNullOrEmpty(extention) || string.IsNullOrWhiteSpace(extention))
                {
                    filesName = tempFileNames;
                    return false;
                }
                


                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[20];
                var random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                var finalString = new String(stringChars);

                fileaName = finalString + extention;

                var bytes = Convert.FromBase64String(img);

                var fullRoot = root + "/" + DateTime.Now.Year + "/" + DateTime.Now.Month;
                if (!Directory.Exists(fullRoot))
                {
                    Directory.CreateDirectory(fullRoot);
                }

                using (var fileStream = new FileStream(Path.Combine(fullRoot, fileaName), FileMode.Create))
                {
                    fileStream.Write(bytes, 0, bytes.Length);
                    fileStream.Flush();
                }
                tempFileNames.Add(fileaName);
            }
            filesName = tempFileNames;
            return true;
        }

        public bool SaveMultiImageFormFileAsync(string root, List<IFormFile> imgs, out List<string> fileName)
        {
            var tempFileNameList = new List<string>();

            foreach (var img in imgs)
            {
                string uniqueFileName = null;
                uniqueFileName = Guid.NewGuid().ToString() + "_" + img.FileName;
                string filePath = Path.Combine(root, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }

                tempFileNameList.Add(uniqueFileName);
                
            }
            fileName = tempFileNameList;
            return true;
        }

        public bool SaveSingleImage(string root, string img, out string fileName)
        {
            var fileaName = "";
            var extention = "";
            var convert = "";
            if (img.Contains("data:image/png"))
            {
                convert = img.Replace("data:image/png;base64,", string.Empty);
                extention = ".png";
            }
            else if (img.Contains("data:image/jpg"))
            {
                convert = img.Replace("data:image/jpg;base64,", string.Empty);
                extention = ".jpg";
            }
            else if (img.Contains("data:image/jpeg"))
            {
                convert = img.Replace("data:image/jpeg;base64,", string.Empty);
                extention = ".jpeg";
            }
            else
            {
                fileName = null;
                return false;
            }

            string converted = convert.Replace('-', '+');
            converted = converted.Replace('_', '/');


            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[20];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);

            fileaName = finalString + extention;


            var bytes = Convert.FromBase64String(converted);

            using (var fileStream = new FileStream(Path.Combine(root, fileaName), FileMode.Create))
            {
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Flush();
            }
            fileName = fileaName;
            return true;
        }

        public bool SaveSingleImageFormFile(string root, IFormFile img, out string fileName)
        {
            string uniqueFileName = null;
            uniqueFileName = Guid.NewGuid().ToString() + "_" + img.FileName;
            string filePath = Path.Combine(root, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                img.CopyTo(fileStream);
            }

            fileName = uniqueFileName;
            return true;
        }
    }
}
