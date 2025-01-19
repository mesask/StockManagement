using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Data;
using StockManagement.Models.Domain;
using StockManagement.Models.ViewModels;
using StockManagement.Services;

namespace StockManagement.Controllers;

public class ItemTypeController(SMDbContext dbContext, IMapper mapper, ItemTypeService service) : Controller
{
    private readonly SMDbContext _dbContext;
    private readonly IMapper _mapper;

    // public ItemTypeController(SMDbContext dbContext, IMapper mapper, ItemTypeService service)
    // {
    //     _dbContext = dbContext;
    //     _mapper = mapper;
    // }

    [HttpGet]
    [ActionName("List")]
    public IActionResult List()
    {
        
        // var itemTypes = new List<ItemTypeListModel>();
        // foreach (var entry in entries)
        // {
        //     var itemType = new ItemTypeListModel
        //     {
        //         Id = entry.Id,
        //         Name = entry.Name,
        //         Image = entry.Image,
        //         Note = entry.Note,
        //     };
        //     itemTypes.Add(itemType);
        // }

        // return View(itemTypes);
        return View(service.SearchAsync());
        
    }

    [HttpGet]
    [ActionName("Add")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ActionName("Add")]
    public IActionResult Add(ItemTypeAddModel model)
    {
        // var itemType = new ItemType
        // {
        //     Name = model.Name,
        //     Image = model.Image,
        //     Note = model.Note,
        // };
        // _dbContext.ItemType.Add(_mapper.Map<ItemType>(model));
        // _dbContext.SaveChanges();
        service.AddAsync(model);
        return RedirectToAction("List");
    }

    [HttpGet]
    [ActionName("Edit")]
    public async Task<IActionResult> Edit(long id)
    {
        // var entry = _dbContext.ItemType.Find(id);
        // if (entry == null)
        // {
        //     return NotFound();
        // }
        //
        // var itemType = new ItemTypeViewModel
        // {
        //     Id = entry.Id,
        //     Name = entry.Name,
        //     Image = entry.Image,
        //     Note = entry.Note,
        // };

        // return View(itemType);
        return View(await service.FindAsync(id));
    }

    
    [HttpPost]
    [ActionName("Edit")]
    public async Task<IActionResult> Edit(ItemTypeEditModel model)
    {
        // var entry = dbContext.ItemType.Find(model.Id);
        // if (entry == null)
        // {
        //     return View("Edit");
        // }
        // entry.Name = model.Name;
        // entry.Image = model.Image;
        // entry.Note = model.Note;
        // dbContext.SaveChanges();
        // return RedirectToAction("List");
        // service.EditAsync(model);
        // return RedirectToAction("List");
        await service.UpdateOrEditAsync(model);
        return RedirectToAction("List");
    }

    
    [HttpGet]
    [ActionName("Delete")]
    // public IActionResult Delete(long id)
    public async Task<IActionResult> Delete(long id)
    {
        // var entry = _dbContext.ItemType.Find(id);
        // if (entry == null)
        // {
        //     return NotFound();
        // }
        //
        // var itemType = new ItemTypeViewModel
        // {
        //     Id = entry.Id,
        //     Name = entry.Name,
        //     Image = entry.Image,
        //     Note = entry.Note,
        // };
        //
        // return View(itemType);
        return View(await service.FindAsync(id));
    }
    
    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> Delete(ItemTypeEditModel model)
    {
        // var entry = _dbContext.ItemType.Find(model.Id);
        // if (entry == null)
        // {
        //     return View("Delete");
        // }
        // _dbContext.ItemType.Remove(entry);
        // _dbContext.SaveChanges();
        //
        // return RedirectToAction("List");
        await service.DeleteAsync(model.Id);
        return RedirectToAction("List");
    }

}