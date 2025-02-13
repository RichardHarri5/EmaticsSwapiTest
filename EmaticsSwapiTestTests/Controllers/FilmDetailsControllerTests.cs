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
        public async Task IndexPageNullUrlTest()
        {
            SWApiClient client = new(new());
            FilmDetailsController controller = new(client);

            RedirectToActionResult? result = await controller.Index(null) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Error", result.ControllerName);
        }

        [TestMethod()]
        public async Task IndexPageEmptyUrlTest()
        {
            SWApiClient client = new(new());
            FilmDetailsController controller = new(client);

            RedirectToActionResult? result = await controller.Index("") as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Error", result.ControllerName);
        }

        [TestMethod()]
        public async Task IndexPageBadHostTest()
        {
            SWApiClient client = new(new());
            FilmDetailsController controller = new(client);

            RedirectToActionResult? result = await controller.Index("films/1") as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Error", result.ControllerName);
        }

        [TestMethod()]
        public async Task IndexPageBadRouteTest()
        {
            SWApiClient client = new(new());
            FilmDetailsController controller = new(client);

            RedirectToActionResult? result = await controller.Index("https://swapi.dev/api/filmsssssssss") as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Error", result.ControllerName);
        }

        [TestMethod()]
        public async Task IndexPageInvalidIdTest()
        {
            SWApiClient client = new(new());
            FilmDetailsController controller = new(client);

            RedirectToActionResult? result = await controller.Index("https://swapi.dev/api/films/9999") as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Error", result.ControllerName);
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