using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using dotnetapp.Models;
namespace dotnetapp.Controllers;
public class CraftController : Controller
{
    // Mock craft data (replace with a craft repository or database)
    private List<Craft> crafts = new List<Craft>
    {
        new Craft { CraftId = 1, Title = "Handmade Pottery", Description = "Beautiful pottery", Price = 25.99m, Quantity = 10 },
        new Craft { CraftId = 2, Title = "Hand-knitted Scarf", Description = "Warm and cozy scarf", Price = 19.99m, Quantity = 15 }
    };

    // Craft listing
    public IActionResult Index()
    {
        return View(crafts);
    }

    // Craft details
    public IActionResult Details(int id)
    {
        var craft = crafts.FirstOrDefault(c => c.CraftId == id);
        if (craft == null)
        {
            return NotFound();
        }

        return View(craft);
    }
}