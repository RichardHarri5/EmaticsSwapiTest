using Microsoft.AspNetCore.Mvc;

namespace EmaticsSwapiTest.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void HomeControllerTest()
        {
            HomeController controller = new();

            ViewResult? result = controller.Error() as ViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("Error", result.ViewName);
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}