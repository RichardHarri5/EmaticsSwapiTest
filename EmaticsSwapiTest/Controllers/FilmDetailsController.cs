using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmaticsSwapiTest.Models;

namespace EmaticsSwapiTest.Controllers;

public class FilmDetailsController : Controller
{
    public FilmDetailsController()
    {

    }

    public IActionResult Index()
    {
        FilmDetailsViewModel viewModel = new();
        return View(viewModel);
    }

}
