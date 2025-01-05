using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Controllers;

public class ItemTypeController : Controller
{
    
    [HttpGet]
    [ActionName("List")]
    public IActionResult List()
    {
        return View();
    }

    [HttpGet]
    [ActionName("Add")]
    public IActionResult Create()
    {
        return View();
    }
}