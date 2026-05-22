using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Controllers;

public class AccountController : Controller
{
    private readonly InMemoryDatabase _db;

    public AccountController(InMemoryDatabase db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            ViewBag.Error = "יש למלא את כל השדות";
            return View();
        }

        var user = _db.GetUserByEmail(email);
        if (user == null || user.Password != password)
        {
            ViewBag.Error = "אימייל או סיסמה שגויים";
            return View();
        }

        HttpContext.Session.SetInt32("UserID", user.UserID);
        HttpContext.Session.SetString("UserName", user.Name);
        HttpContext.Session.SetString("IsAdmin", user.IsAdmin.ToString());

        TempData["Success"] = $"ברוך הבא, {user.Name}!";

        if (user.IsAdmin)
            return RedirectToAction("Index", "Admin");
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(string name, string email, string password, string confirmPassword)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            ViewBag.Error = "יש למלא את כל השדות";
            return View();
        }

        if (password != confirmPassword)
        {
            ViewBag.Error = "הסיסמאות אינן תואמות";
            return View();
        }

        if (password.Length < 6)
        {
            ViewBag.Error = "הסיסמה חייבת להכיל לפחות 6 תווים";
            return View();
        }

        if (_db.GetUserByEmail(email) != null)
        {
            ViewBag.Error = "אימייל זה כבר רשום במערכת";
            return View();
        }

        var user = _db.AddUser(new User
        {
            Name = name,
            Email = email,
            Password = password,
            IsAdmin = false
        });

        HttpContext.Session.SetInt32("UserID", user.UserID);
        HttpContext.Session.SetString("UserName", user.Name);
        HttpContext.Session.SetString("IsAdmin", "False");

        TempData["Success"] = $"נרשמת בהצלחה! ברוך הבא, {user.Name}";
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        TempData["Success"] = "התנתקת בהצלחה";
        return RedirectToAction("Index", "Home");
    }

    public IActionResult MyOrders()
    {
        var userId = HttpContext.Session.GetInt32("UserID");
        if (userId == null)
            return RedirectToAction("Login");

        var orders = _db.GetOrdersByUserId(userId.Value);
        return View(orders);
    }
}
