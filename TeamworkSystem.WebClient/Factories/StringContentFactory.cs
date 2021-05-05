using System.Net.Http;
using System.Text;

namespace TeamworkSystem.WebClient.Factories
{
    public class StringContentFactory
    {
        public static StringContent BuildStringContent(string content) =>
            new(content, Encoding.UTF8, "application/json");
    }
}
