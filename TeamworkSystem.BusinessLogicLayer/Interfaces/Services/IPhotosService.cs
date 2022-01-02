using Microsoft.AspNetCore.Http;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces.Services
{
    public interface IPhotosService
    {
        Task<string> SavePhotoAsync(IFormFile photo);
    }
}
