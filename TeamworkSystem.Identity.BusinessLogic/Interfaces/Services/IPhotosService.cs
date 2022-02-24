using Microsoft.AspNetCore.Http;

namespace TeamworkSystem.Identity.BusinessLogic.Interfaces.Services;

public interface IPhotosService
{
    Task<string> SavePhotoAsync(IFormFile photo);
}
