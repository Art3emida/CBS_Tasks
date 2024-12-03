namespace BookStore.Controllers;

using Microsoft.AspNetCore.Mvc;

public class SiteController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("index", "authors");
    }

    public IActionResult Error()
    {
        return View();
    }
}
