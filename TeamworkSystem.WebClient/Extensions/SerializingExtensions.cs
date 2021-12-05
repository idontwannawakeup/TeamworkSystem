using System.Text.Json;

namespace TeamworkSystem.WebClient.Extensions
{
    public static class SerializingExtensions
    {
        public static string Serialize<T>(this T obj) =>
            JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

        public static TOut Deserialize<TOut>(this string obj) =>
            JsonSerializer.Deserialize<TOut>(obj, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
    }
}
