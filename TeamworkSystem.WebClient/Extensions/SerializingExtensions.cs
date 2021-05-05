using System.Text.Json;

namespace TeamworkSystem.WebClient.Extensions
{
    public static class SerializingExtensions
    {
        public static string Serialize<T>(this T obj) =>
            JsonSerializer.Serialize(obj, new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

        public static TOut Deserialize<TOut>(this string obj)
            => JsonSerializer.Deserialize<TOut>(obj);
    }
}
