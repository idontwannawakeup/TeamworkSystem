using Microsoft.AspNetCore.Http;

namespace TeamworkSystem.WorkManagement.Application.Interfaces.Data.Storages;

public interface IPhotoStorage
{
    Task<string> SavePhotoAsync(IFormFile photo);
}
