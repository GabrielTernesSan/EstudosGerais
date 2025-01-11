using System.Net.Http.Headers;

namespace Alura.Adopet.Console.Servicos
{
    internal class AdopetAPIClientFactory : IHttpClientFactory
    {
        private string uri = "http://localhost:5057";
        public HttpClient CreateClient(string name)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(uri);
            return _client;
        }
    }
}
