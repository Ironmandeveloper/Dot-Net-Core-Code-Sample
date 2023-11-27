using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Services.FileHandlingServices
{
    public class FileHandlingService : IFileHandlingService
    {
        public dynamic DeleteFileOnServer(string AbsoluteStoragePath)
        {
            try
            {
                  FileInfo file = new FileInfo(AbsoluteStoragePath);
                    if (file.Exists)//check file exsits or not  
                    {
                        file.Delete();
                    }
                    return "file has been deleted successfully";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public dynamic SaveFileOnServer(IFormFile file, string DirectoryPath, string AbsoluteStoragePath)
        {
            try
            {
                if (!Directory.Exists(DirectoryPath))
                    Directory.CreateDirectory(DirectoryPath);

                using (var stream = new FileStream(AbsoluteStoragePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return "file has been saved successfully";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ValidateFileExtension(string[]? AllowedExtensions, string UploadedFileName)
        {
            try
            {
                if (!AllowedExtensions.Contains(Path.GetExtension(UploadedFileName.ToLower())))
                {
                    return false;
                }
                return true;
            }
            catch (Exception) { throw; }
        }
    }
}
