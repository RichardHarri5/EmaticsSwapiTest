using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmaticsSwapiTest.ViewModels;

namespace EmaticsSwapiTest.Controllers;

public class ErrorController : Controller
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Index()
    {
        ErrorViewModel viewModel = new() { RequestId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier };
        ViewResult result = View("Index", viewModel);
        result.StatusCode = 200;
        return result;
    }
}
