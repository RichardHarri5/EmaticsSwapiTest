using Microsoft.AspNetCore.Mvc;

namespace EmaticsSwapiTest.Controllers.Tests
{
    [TestClass()]
    public class ErrorControllerTests
    {
        [TestMethod()]
        public void ErrorPageLoadTest()
        {
            ErrorController controller = new();

            ViewResult? result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}