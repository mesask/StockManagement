using Microsoft.AspNetCore.Mvc;
using StockManagement.Models.ViewModels;
using StockManagement.Services;

namespace StockManagement.Controllers;

public class ItemController(ItemService service) : Controller
{
    // GET
    public async Task<IActionResult> List 
        //(string searchQuery, string sortBy, string sortDirection)
    (string searchQuery, string sortBy, string sortDirection, int pageNumber = 1, int pageSize = 3)
    {
        var totalRecords = await service.CountAsync();
        var totalPages = Math.Ceiling((double)totalRecords / (pageSize));
        if (pageNumber > totalPages)
        {
            pageNumber = (int)totalPages;
        }

        if (pageNumber < 1)
        {
            pageNumber = 1;
        }
        
        ViewBag.TotalPages = totalPages;
        ViewBag.PageNumber = pageNumber;
        ViewBag.PageSize = pageSize;
        ViewBag.SortBy = sortBy;
        ViewBag.SortDirection = sortDirection;
        ViewBag.SearchQuery = searchQuery;
        
        var items = await service.SearchAsync(searchQuery, sortBy, sortDirection, pageNumber, pageSize);
        return View(items);
    }

    public IActionResult Add()
    {
        return View();
    }

    [ActionName("Add")]
    [HttpPost]
    public async Task<IActionResult> Add(ItemAddModel model)
    {
        var item = await service.AddAsync(model);
        if (item != null)
        {
            return RedirectToAction("List");
        }
        return View("Add", model);
        //     var item = await.service.AddAsync(model);
        //     if (item != null)
        //     {
        //         return RedirectToAction("List");
        //     }
        //     return View("Add", model);
        // }
    }
    
    // [HttpGet]
    // [ActionName("Edit")]
    // public async Task<IActionResult> Edit(long id)
    // {
    //     return View(await service.FindAsync(id));
    // }
    //
    // [HttpPost]
    // [ActionName("Edit")]
    // public async Task<IActionResult> Edit(ItemEditModel model)
    // {
    //     await service.UpdateOrEditAsync(model);
    //     return RedirectToAction("List");
    // }
}