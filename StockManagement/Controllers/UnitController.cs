using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Data;
using StockManagement.Models.Domain;
using StockManagement.Models.ViewModels;
using StockManagement.Services;

namespace StockManagement.Controllers;

public class UnitController(SMDbContext dbContext, IMapper mapper, UnitService service) : Controller
{
    private readonly SMDbContext _dbContext;
    private readonly IMapper _mapper;

    [HttpGet]
    [ActionName("List")]
    public async Task<IActionResult> List()
    {
        return View(await service.SearchAsync());
    }

    [HttpGet]
    [ActionName("Add")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ActionName("Add")]
    public async Task<IActionResult> Add(UnitAddModel model)
    {
        await service.AddAsync(model);
        return RedirectToAction("List");
    }

    [HttpGet]
    [ActionName("Edit")]
    public async Task<IActionResult> Edit(long id)
    {
        return View(await service.FindAsync(id));
    }

    [HttpPost]
    [ActionName("Edit")]
    public async Task<IActionResult> Edit(UnitEditModel model)
    {
        await service.UpdateOrEditAsync(model);
        return RedirectToAction("List");
    }

    [HttpGet]
    [ActionName("Delete")]
    public async Task<IActionResult> Delete(long id)
    {
        return View(await service.FindAsync(id));
    }

    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> Delete(UnitEditModel model)
    {
        await service.DeleteAsync(model.Id);
        return RedirectToAction("List");
    }
}