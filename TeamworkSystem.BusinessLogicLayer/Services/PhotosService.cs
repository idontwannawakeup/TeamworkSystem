using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;

namespace TeamworkSystem.BusinessLogicLayer.Services
{
    public class PhotosService : IPhotosService
    {
        private readonly IWebHostEnvironment environment;

        public async Task<string> SavePhotoAsync(IFormFile photo)
        {
            const string photosFolderPath = "Public\\Photos";

            if (!Directory.Exists($"{environment.WebRootPath}\\{photosFolderPath}\\"))
            {
                Directory.CreateDirectory($"{environment.WebRootPath}\\{photosFolderPath}\\");
            }

            string fileExtension = Path.GetExtension(photo.FileName);
            string fileName = $"{DateTime.Now:yyyyMMddHHmmssffff}{fileExtension}";
            await using var fileStream = File.Create(
                $"{environment.WebRootPath}\\{photosFolderPath}\\{fileName}");

            photo.CopyTo(fileStream);
            await fileStream.FlushAsync();

            return fileName;
        }

        public PhotosService(IWebHostEnvironment environment) => this.environment = environment;
    }
}
