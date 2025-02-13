using EmaticsSwapiTest.Models;
using EmaticsSwapiTest.ViewModels;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json;

namespace EmaticsSwapiTest
{
    public class SWApiClient(HttpClient client) : ISWApiClient
    {
        private HttpClient Client { get; } = client;
        private JsonSerializerOptions JsonOptions { get; } = new() { PropertyNameCaseInsensitive = true };

        public async Task<FilmsViewModel> GetFilms(string url)
        {
            Film[] filmsData = await GetAllFilms(url);

            FilmsViewModel model = new()
            {
                FilmsTable = [..
                    filmsData.Select(f => new FilmInfo
                    {
                        Title = f.Title,
                        EpisodeId = f.Episode_Id,
                        ReleaseDate = f.Release_Date,
                        FilmUrl = f.Url
                    })
                ]
            };
            return model;
        }

        public async Task<FilmDetailsViewModel?> GetFilmDetails(string url)
        {
            throw new NotImplementedException();
        }

        private async Task<Film[]?> GetAllFilms(string url)
        {
            string responseBody = await SendRequest(url);
            return JsonSerializer.Deserialize<Film[]?>(responseBody, JsonOptions);
        }

        private async Task<Film?> GetFilm(string url)
        {
            throw new NotImplementedException();
        }

        private async Task<Character?> GetCharacter(string url)
        {
            throw new NotImplementedException();
        }

        private async Task<Planet?> GetPlanet(string url)
        {
            throw new NotImplementedException();
        }

        private async Task<string> SendRequest(string url)
        {
            HttpRequestMessage request = new(HttpMethod.Get, url);

            HttpResponseMessage response = await Client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
