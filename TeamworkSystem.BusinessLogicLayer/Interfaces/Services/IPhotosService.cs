using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TeamworkSystem.BusinessLogicLayer.Interfaces.Services
{
    public interface IPhotosService
    {
        Task<string> SavePhotoAsync(IFormFile photo);
    }
}
