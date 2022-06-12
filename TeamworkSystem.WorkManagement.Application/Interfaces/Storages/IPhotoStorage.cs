using Microsoft.AspNetCore.Http;

namespace TeamworkSystem.WorkManagement.Application.Interfaces.Storages;

public interface IPhotoStorage
{
    Task<string> SavePhotoAsync(IFormFile photo);
}
