using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;

namespace MusicStore.Controllers;

public class ProductsController : Controller
{
    private readonly InMemoryDatabase _db;

    public ProductsController(InMemoryDatabase db)
    {
        _db = db;
    }

    public IActionResult Index(int? categoryId, string? search)
    {
        var products = _db.Products.AsEnumerable();

        if (categoryId.HasValue)
        {
            products = products.Where(p => p.CategoryID == categoryId.Value);
            ViewBag.SelectedCategory = _db.GetCategoryById(categoryId.Value);
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            var keyword = search.ToLower();
            products = products.Where(p =>
                p.ProductName.ToLower().Contains(keyword) ||
                p.Description.ToLower().Contains(keyword) ||
                p.Brand.ToLower().Contains(keyword));
            ViewBag.SearchTerm = search;
        }

        ViewBag.Categories = _db.Categories;
        return View(products.ToList());
    }

    public IActionResult Details(int id)
    {
        var product = _db.GetProductById(id);
        if (product == null)
            return NotFound();

        ViewBag.Category = _db.GetCategoryById(product.CategoryID);
        ViewBag.Related = _db.Products
            .Where(p => p.CategoryID == product.CategoryID && p.ProductID != product.ProductID)
            .Take(4)
            .ToList();
        return View(product);
    }
}
