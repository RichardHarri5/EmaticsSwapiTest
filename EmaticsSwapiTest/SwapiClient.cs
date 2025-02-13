using EmaticsSwapiTest.Models;
using EmaticsSwapiTest.ViewModels;
using Microsoft.AspNetCore.Http.Json;
using System;
using System.Text.Json;

namespace EmaticsSwapiTest
{
    public class SWApiClient(HttpClient client) : ISWApiClient
    {
        private HttpClient Client { get; } = client;
        private JsonSerializerOptions JsonOptions { get; } = new() { PropertyNameCaseInsensitive = true };

        public async Task<FilmsViewModel> GetFilms(string url)
        {
            Film[]? filmsData = await GetAllFilms(url) ?? throw new ArgumentException($"No Data Found For {url}");

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

            return model ?? throw new ArgumentException($"Cannot Build View For {url}");
        }

        public async Task<FilmDetailsViewModel?> GetFilmDetails(string url)
        {
            Film? filmData = await GetFilm(url) ?? throw new ArgumentException($"No Data Found For {url}");

            HashSet<string>? planetUrls = [.. filmData?.Planets];
            Dictionary<string, Person> characters = [];
            Dictionary<string, Planet> planets = [];

            foreach (string characterUrl in filmData.Characters)
            {
                Person? c = await GetPerson(characterUrl);
                if (c is not null)
                {
                    characters[characterUrl] = c;
                    planetUrls.Add(c.HomeWorld);
                }
            }

            foreach (string planetUrl in planetUrls)
            {
                Planet? p = await GetPlanet(planetUrl);
                if (p is not null)
                {
                    planets[planetUrl] = p;
                }
            }

            FilmDetailsViewModel model = new()
            {
                Film = new FilmExtra
                {
                    Title = filmData.Title,
                    EpisodeId = filmData.Episode_Id,
                    ReleaseDate = filmData.Release_Date,
                    TextCrawl = filmData.Opening_Crawl,
                    FilmUrl = filmData.Url,
                    Planets = [.. planets.Where(p => filmData.Planets.Contains(p.Key, StringComparer.InvariantCultureIgnoreCase)).Select(p => new PlanetInfo() { Name = p.Value.Name })],
                    HomeWorlds = [..
                        characters.GroupBy(c => c.Value.HomeWorld)
                            .Select(g =>
                            {
                                Planet? homeWorld = planets[g.Key];
                                return new PlanetExtra
                                {
                                    Name = homeWorld.Name,
                                    Characters = [.. g.Select(c => new CharacterInfo() { Name = c.Value.Name} )]
                                };
                            })
                    ]
                }
            };

            return model ?? throw new ArgumentException($"Cannot Build View For {url}");
        }

        private async Task<Film[]?> GetAllFilms(string url)
        {
            string responseBody = await SendRequest(url);
            return JsonSerializer.Deserialize<FilmList>(responseBody, JsonOptions)?.Results;
        }

        private async Task<Film?> GetFilm(string url)
        {
            string responseBody = await SendRequest(url);
            return JsonSerializer.Deserialize<Film>(responseBody, JsonOptions);
        }

        private async Task<Person?> GetPerson(string url)
        {
            string responseBody = await SendRequest(url);
            return JsonSerializer.Deserialize<Person>(responseBody, JsonOptions);
        }

        private async Task<Planet?> GetPlanet(string url)
        {
            string responseBody = await SendRequest(url);
            return JsonSerializer.Deserialize<Planet>(responseBody, JsonOptions);
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
