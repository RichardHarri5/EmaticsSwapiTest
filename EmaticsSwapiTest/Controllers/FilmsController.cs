using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmaticsSwapiTest.Models;

namespace EmaticsSwapiTest.Controllers;

public class FilmsController : Controller
{
    public FilmsController()
    {

    }

    public IActionResult Index()
    {
        FilmsViewModel viewModel = new();
        return View(viewModel);
    }

}
