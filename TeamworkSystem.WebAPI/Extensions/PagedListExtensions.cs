using System.Text.Json;
using TeamworkSystem.DataAccessLayer.Pagination;

namespace TeamworkSystem.WebAPI.Extensions
{
    public static class PagedListExtensions
    {
        public static string SerializeMetadata<T>(this PagedList<T> list) =>
            JsonSerializer.Serialize(list.Metadata,
                                     new JsonSerializerOptions
                                     {
                                         PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                     });
    }
}
