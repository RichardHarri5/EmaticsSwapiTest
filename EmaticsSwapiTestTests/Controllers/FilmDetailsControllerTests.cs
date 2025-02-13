using Microsoft.AspNetCore.Mvc;
using EmaticsSwapiTest.ViewModels;

namespace EmaticsSwapiTest.Controllers.Tests
{
    [TestClass()]
    public class FilmDetailsControllerTests
    {
        [TestMethod()]
        public async Task IndexPageLoadTest()
        {
            SWApiClient client = new(new());
            FilmDetailsController controller = new(client);

            ViewResult? result = await controller.Index("https://swapi.dev/api/films/1") as ViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod()]
        public async Task IndexDataTest()
        {
            SWApiClient client = new(new());
            FilmDetailsController controller = new(client);

            ViewResult? result = await controller.Index("https://swapi.dev/api/films/1") as ViewResult;

            Assert.IsNotNull(result);

            FilmDetailsViewModel? model = result.Model as FilmDetailsViewModel;
            Assert.IsNotNull(model);
        }
    }
}