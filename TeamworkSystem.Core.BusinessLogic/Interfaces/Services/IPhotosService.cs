using Microsoft.AspNetCore.Http;

namespace TeamworkSystem.Core.BusinessLogic.Interfaces.Services;

public interface IPhotosService
{
    Task<string> SavePhotoAsync(IFormFile photo);
}
