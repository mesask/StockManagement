using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Controllers;

public class ItemController : Controller
{
    // GET
    public IActionResult List()
    {
        return View();
    }

    public IActionResult Add()
    {
        return View();
    }
}