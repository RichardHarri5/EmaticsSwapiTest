using EmaticsSwapiTest.ViewModels;

namespace EmaticsSwapiTest.Tests
{
    [TestClass()]
    public class SWApiClientTests
    {
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task GetFilmsNullTest()
        {
            SWApiClient client = new(new());
            _ = await client.GetFilms(null);

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task GetFilmsEmptyTest()
        {
            SWApiClient client = new(new());
            _ = await client.GetFilms("");

            Assert.Fail();
        }
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task GetFilmsBadHostTest()
        {
            SWApiClient client = new(new());
            _ = await client.GetFilms("films");

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(HttpRequestException))]
        public async Task GetFilmsBadRouteTest()
        {
            SWApiClient client = new(new());
            _ = await client.GetFilms("https://swapi.dev/api/filmsssssssss");

            Assert.Fail();
        }

        [TestMethod()]
        public async Task GetFilmsTest()
        {
            SWApiClient client = new(new());
            FilmsViewModel? films = await client.GetFilms("https://swapi.dev/api/films");

            Assert.IsNotNull(films);

            Assert.AreEqual(6, films.FilmsTable.Length);
            FilmInfo testFilm = films.FilmsTable.FirstOrDefault(f => f.Title == "A New Hope");
            Assert.IsNotNull(testFilm);
            Assert.AreEqual("A New Hope", testFilm.Title);
            Assert.AreEqual(4, testFilm.EpisodeId);
            Assert.AreEqual(new DateTime(1977, 5, 25), testFilm.ReleaseDate);
            Assert.AreEqual("https://swapi.dev/api/films/1/", testFilm.FilmUrl);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task GetFilmDetailsNullTest()
        {
            SWApiClient client = new(new());
            _ = await client.GetFilmDetails(null);

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task GetFilmDetailsEmptyTest()
        {
            SWApiClient client = new(new());
            _ = await client.GetFilmDetails("");

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task GetFilmDetailsBadHostTest()
        {
            SWApiClient client = new(new());
            _ = await client.GetFilmDetails("films/1");

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(HttpRequestException))]
        public async Task GetFilmDetailsBadRouteTest()
        {
            SWApiClient client = new(new());
            _ = await client.GetFilmDetails("https://swapi.dev/api/filmsssssssss/1");

            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(HttpRequestException))]
        public async Task GetFilmDetailsInvalidIdTest()
        {
            SWApiClient client = new(new());
            _ = await client.GetFilmDetails("https://swapi.dev/api/films/999999");

            Assert.Fail();
        }

        [TestMethod()]
        public async Task GetFilmDetailsTest()
        {
            SWApiClient client = new(new());
            FilmDetailsViewModel? film = await client.GetFilmDetails("https://swapi.dev/api/films/1");

            Assert.IsNotNull(film);

            FilmExtra testFilm = film.Film;
            Assert.IsNotNull(testFilm);
            Assert.AreEqual("A New Hope", testFilm.Title);
            Assert.AreEqual(4, testFilm.EpisodeId);
            Assert.AreEqual(new DateTime(1977, 5, 25), testFilm.ReleaseDate);
            Assert.AreEqual("https://swapi.dev/api/films/1/", testFilm.FilmUrl);
            Assert.AreEqual(3, testFilm.Planets.Length);
            Assert.IsTrue(testFilm.HomeWorlds.Any());
            Assert.IsTrue(testFilm.HomeWorlds.All(h => h.Characters.Any()));
        }
    }
}