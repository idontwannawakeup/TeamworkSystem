using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;

namespace TeamworkSystem.BusinessLogicLayer.Services;

public class PhotosService : IPhotosService
{
    private readonly IWebHostEnvironment _environment;

    public PhotosService(IWebHostEnvironment environment) => _environment = environment;

    public async Task<string> SavePhotoAsync(IFormFile photo)
    {
        const string photosFolderPath = "Public\\Photos";

        if (!Directory.Exists($"{_environment.WebRootPath}\\{photosFolderPath}\\"))
        {
            Directory.CreateDirectory($"{_environment.WebRootPath}\\{photosFolderPath}\\");
        }

        var fileExtension = Path.GetExtension(photo.FileName);
        var fileName = $"{DateTime.Now:yyyyMMddHHmmssffff}{fileExtension}";
        await using var fileStream = File.Create(
            $"{_environment.WebRootPath}\\{photosFolderPath}\\{fileName}");

        await photo.CopyToAsync(fileStream);
        await fileStream.FlushAsync();

        return fileName;
    }
}
