using System.Net.Http;
using System.Threading.Tasks;

namespace Voluntariese.Api.Infraestrutura.Utilitarios
{
    public static class UtilitarioDownload
    {
        public static async Task<byte[]> Download(string url)
        {
            using (var client = new HttpClient())
            using (var result = await client.GetAsync(url))
            {
                if (result.IsSuccessStatusCode)
                {
                    return await result.Content.ReadAsByteArrayAsync();
                }
                return null;
            }
        }
    }
}
