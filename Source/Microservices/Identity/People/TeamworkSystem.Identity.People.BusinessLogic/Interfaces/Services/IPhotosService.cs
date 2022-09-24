using Microsoft.AspNetCore.Http;

namespace TeamworkSystem.Identity.People.BusinessLogic.Interfaces.Services;

public interface IPhotosService
{
    Task<string> SavePhotoAsync(IFormFile photo);
}
