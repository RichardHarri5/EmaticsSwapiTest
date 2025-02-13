using EmaticsSwapiTest.ViewModels;

namespace EmaticsSwapiTest
{
    public interface ISWApiClient
    {
        public Task<FilmsViewModel?> GetFilms(string url);
        public Task<FilmDetailsViewModel?> GetFilmDetails(string url);
    }
}
