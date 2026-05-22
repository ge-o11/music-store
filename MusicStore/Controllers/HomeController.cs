using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Controllers;

public class HomeController : Controller
{
    private readonly InMemoryDatabase _db;

    public HomeController(InMemoryDatabase db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        ViewBag.Categories = _db.Categories;
        ViewBag.FeaturedProducts = _db.Products.Take(8).ToList();
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View();
    }
}
