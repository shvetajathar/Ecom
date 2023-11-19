using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using dotnetapp.Models;
namespace dotnetapp.Controllers;
public class AccountController : Controller
{
    // Mock user data (replace with a user repository or identity management system)
    private List<User> users = new List<User>
    {
        new User { UserId = 1, Email = "customer@example.com", Password = "password" },
        new User { UserId = 2, Email = "seller@example.com", Password = "password" }
    };

    // Registration
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User newUser)
    {
        // Add logic to validate and save the new user (e.g., to a database)
        users.Add(newUser);
        return RedirectToAction("Login");
    }

    // Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(User user)
    {
        // Add logic to authenticate the user (e.g., check credentials against a database)
        var authenticatedUser = users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

        if (authenticatedUser != null)
        {
            // Add authentication logic (e.g., set a cookie or use Identity)
            return RedirectToAction("Index", "Home");
        }

        // Authentication failed, return to login
        return View();
    }

    // Logout
    public IActionResult Logout()
    {
        // Add logic to log out the user (e.g., clear authentication cookie)
        return RedirectToAction("Index", "Home");
    }
}