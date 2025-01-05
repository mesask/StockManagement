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
}