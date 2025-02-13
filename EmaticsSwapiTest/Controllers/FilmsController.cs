using Microsoft.AspNetCore.Mvc;
using EmaticsSwapiTest.ViewModels;

namespace EmaticsSwapiTest.Controllers;

public class FilmsController(ISWApiClient swApiClient) : Controller
{
    public async Task<IActionResult> Index()
    {
        try
        {
            FilmsViewModel? viewModel = await swApiClient.GetFilms("https://swapi.dev/api/films");
            return View(viewModel);
        }
        catch
        {
            return RedirectToAction("Error", "Home");
        }
    }
}
