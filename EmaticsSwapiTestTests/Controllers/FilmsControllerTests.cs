using EmaticsSwapiTest.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmaticsSwapiTest.Controllers.Tests
{
    [TestClass()]
    public class FilmsControllerTests
    {
        [TestMethod()]
        public async Task IndexPageLoadTest()
        {
            SWApiClient client = new(new());
            FilmsController controller = new(client);

            ViewResult? result = await controller.Index() as ViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod()]
        public async Task IndexDataTest()
        {
            SWApiClient client = new(new());
            FilmsController controller = new(client);

            ViewResult? result = await controller.Index() as ViewResult;

            Assert.IsNotNull(result);

            FilmsViewModel? model = result.Model as FilmsViewModel;
            Assert.IsNotNull(model);
        }
    }
}