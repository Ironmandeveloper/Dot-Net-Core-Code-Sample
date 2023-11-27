using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FileHandlingServices
{
    public interface IFileHandlingService
    {
        dynamic SaveFileOnServer(IFormFile file,string DirectoryPath,string AbsoluteStoragePath);
        dynamic DeleteFileOnServer(string AbsoluteStoragePath);
        bool ValidateFileExtension(string[]? AllowedExtensions,string UploadedFileName);
    }
}
