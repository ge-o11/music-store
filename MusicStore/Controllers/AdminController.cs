using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Controllers;

public class AdminController : Controller
{
    private readonly InMemoryDatabase _db;

    public AdminController(InMemoryDatabase db)
    {
        _db = db;
    }

    private bool IsAdmin()
    {
        var isAdmin = HttpContext.Session.GetString("IsAdmin");
        return isAdmin == "True";
    }

    private IActionResult? CheckAdmin()
    {
        if (!IsAdmin())
        {
            TempData["Error"] = "אין לך הרשאת מנהל";
            return RedirectToAction("Login", "Account");
        }
        return null;
    }

    public IActionResult Index()
    {
        var check = CheckAdmin();
        if (check != null) return check;

        ViewBag.TotalProducts = _db.Products.Count;
        ViewBag.TotalUsers = _db.Users.Count;
        ViewBag.TotalOrders = _db.Orders.Count;
        ViewBag.TotalRevenue = _db.Orders.Sum(o => o.TotalPrice);
        ViewBag.RecentOrders = _db.Orders.OrderByDescending(o => o.OrderDate).Take(5).ToList();
        ViewBag.Users = _db.Users;
        return View(_db.Products);
    }

    [HttpGet]
    public IActionResult AddProduct()
    {
        var check = CheckAdmin();
        if (check != null) return check;

        ViewBag.Categories = _db.Categories;
        return View();
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        var check = CheckAdmin();
        if (check != null) return check;

        if (string.IsNullOrWhiteSpace(product.ProductName) || product.Price <= 0)
        {
            ViewBag.Categories = _db.Categories;
            ViewBag.Error = "יש למלא את כל השדות בצורה תקינה";
            return View(product);
        }

        if (string.IsNullOrWhiteSpace(product.Image))
            product.Image = "https://via.placeholder.com/600x400?text=No+Image";

        _db.AddProduct(product);
        TempData["Success"] = $"המוצר \"{product.ProductName}\" נוסף בהצלחה";
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult EditProduct(int id)
    {
        var check = CheckAdmin();
        if (check != null) return check;

        var product = _db.GetProductById(id);
        if (product == null) return NotFound();

        ViewBag.Categories = _db.Categories;
        return View(product);
    }

    [HttpPost]
    public IActionResult EditProduct(Product product)
    {
        var check = CheckAdmin();
        if (check != null) return check;

        if (_db.UpdateProduct(product))
        {
            TempData["Success"] = "המוצר עודכן בהצלחה";
            return RedirectToAction("Index");
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult DeleteProduct(int id)
    {
        var check = CheckAdmin();
        if (check != null) return check;

        if (_db.DeleteProduct(id))
        {
            TempData["Success"] = "המוצר נמחק בהצלחה";
        }
        return RedirectToAction("Index");
    }

    public IActionResult Orders()
    {
        var check = CheckAdmin();
        if (check != null) return check;

        var orders = _db.Orders.OrderByDescending(o => o.OrderDate).ToList();
        ViewBag.Users = _db.Users.ToDictionary(u => u.UserID, u => u.Name);
        return View(orders);
    }
}
