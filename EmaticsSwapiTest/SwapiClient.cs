namespace EmaticsSwapiTest
{
    public class SWApiClient : ISWApiClient
    {
        private readonly HttpClient _httpClient;
        public SWApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
