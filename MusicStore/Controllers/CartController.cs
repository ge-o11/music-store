using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;
using System.Text.Json;

namespace MusicStore.Controllers;

public class CartController : Controller
{
    private readonly InMemoryDatabase _db;
    private const string CartSessionKey = "ShoppingCart";

    public CartController(InMemoryDatabase db)
    {
        _db = db;
    }

    private List<CartItem> GetCart()
    {
        var cartJson = HttpContext.Session.GetString(CartSessionKey);
        if (string.IsNullOrEmpty(cartJson))
            return new List<CartItem>();
        return JsonSerializer.Deserialize<List<CartItem>>(cartJson) ?? new List<CartItem>();
    }

    private void SaveCart(List<CartItem> cart)
    {
        HttpContext.Session.SetString(CartSessionKey, JsonSerializer.Serialize(cart));
    }

    public IActionResult Index()
    {
        var cart = GetCart();
        ViewBag.Total = cart.Sum(c => c.Subtotal);
        return View(cart);
    }

    [HttpPost]
    public IActionResult Add(int productId, int quantity = 1)
    {
        var product = _db.GetProductById(productId);
        if (product == null)
            return NotFound();

        var cart = GetCart();
        var existing = cart.FirstOrDefault(c => c.ProductID == productId);

        if (existing != null)
        {
            existing.Quantity += quantity;
        }
        else
        {
            cart.Add(new CartItem
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Price = product.Price,
                Quantity = quantity,
                Image = product.Image
            });
        }

        SaveCart(cart);
        TempData["Success"] = $"\"{product.ProductName}\" נוסף לעגלה";
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Update(int productId, int quantity)
    {
        var cart = GetCart();
        var item = cart.FirstOrDefault(c => c.ProductID == productId);
        if (item != null)
        {
            if (quantity <= 0)
                cart.Remove(item);
            else
                item.Quantity = quantity;
            SaveCart(cart);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Remove(int productId)
    {
        var cart = GetCart();
        cart.RemoveAll(c => c.ProductID == productId);
        SaveCart(cart);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Checkout()
    {
        var userId = HttpContext.Session.GetInt32("UserID");
        if (userId == null)
        {
            TempData["Error"] = "יש להתחבר לפני ביצוע הזמנה";
            return RedirectToAction("Login", "Account");
        }

        var cart = GetCart();
        if (!cart.Any())
        {
            TempData["Error"] = "העגלה ריקה";
            return RedirectToAction("Index");
        }

        var order = new Order
        {
            UserID = userId.Value,
            TotalPrice = cart.Sum(c => c.Subtotal),
            OrderDate = DateTime.Now,
            Status = "Confirmed",
            Items = cart.Select(c => new OrderItem
            {
                ProductID = c.ProductID,
                ProductName = c.ProductName,
                Price = c.Price,
                Quantity = c.Quantity
            }).ToList()
        };

        _db.AddOrder(order);
        HttpContext.Session.Remove(CartSessionKey);
        TempData["Success"] = $"ההזמנה בוצעה בהצלחה! מספר הזמנה: #{order.OrderID}";
        return RedirectToAction("OrderConfirmation", new { id = order.OrderID });
    }

    public IActionResult OrderConfirmation(int id)
    {
        var order = _db.Orders.FirstOrDefault(o => o.OrderID == id);
        if (order == null)
            return NotFound();
        return View(order);
    }
}
