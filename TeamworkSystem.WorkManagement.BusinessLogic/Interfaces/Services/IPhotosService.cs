using Microsoft.AspNetCore.Http;

namespace TeamworkSystem.WorkManagement.BusinessLogic.Interfaces.Services;

public interface IPhotosService
{
    Task<string> SavePhotoAsync(IFormFile photo);
}
