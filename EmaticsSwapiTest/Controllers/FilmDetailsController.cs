using Microsoft.AspNetCore.Mvc;
using EmaticsSwapiTest.ViewModels;

namespace EmaticsSwapiTest.Controllers;

public class FilmDetailsController(ISWApiClient swApiClient) : Controller
{
    public async Task<IActionResult> Index(string filmUrl)
    {
        try
        {
            FilmDetailsViewModel? viewModel = await swApiClient.GetFilmDetails(filmUrl);
            return View(viewModel);
        }
        catch
        {
            return RedirectToAction("Error", "Home");
        }
    }

}
