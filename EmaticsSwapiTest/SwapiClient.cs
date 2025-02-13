using EmaticsSwapiTest.ViewModels;

namespace EmaticsSwapiTest
{
    public class SWApiClient(HttpClient client) : ISWApiClient
    {
        private HttpClient Client { get; } = client;

        public async Task<FilmsViewModel> GetFilms(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<FilmDetailsViewModel?> GetFilmDetails(string url)
        {
            throw new NotImplementedException();
        }

    }
}
