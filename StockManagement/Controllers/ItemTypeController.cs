using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Data;
using StockManagement.Models.Domain;
using StockManagement.Models.ViewModels;

namespace StockManagement.Controllers;

public class ItemTypeController : Controller
{
    private readonly SMDbContext _dbContext;
    private readonly IMapper _mapper;

    public ItemTypeController(SMDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet]
    [ActionName("List")]
    public IActionResult List()
    {
        var entries = _dbContext.ItemType.ToList();
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
        return View(_mapper.Map<List<ItemTypeListModel>>(entries));
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
        _dbContext.ItemType.Add(_mapper.Map<ItemType>(model));
        _dbContext.SaveChanges();
        return RedirectToAction("List");
    }

    [HttpGet]
    [ActionName("Edit")]
    public IActionResult Edit(long id)
    {
        var entry = _dbContext.ItemType.Find(id);
        if (entry == null)
        {
            return NotFound();
        }

        var itemType = new ItemTypeViewModel
        {
            Id = entry.Id,
            Name = entry.Name,
            Image = entry.Image,
            Note = entry.Note,
        };

        return View(itemType);
    }

    
    [HttpPost]
    [ActionName("Edit")]
    public IActionResult Edit(ItemTypeEditModel model)
    {
        var entry = _dbContext.ItemType.Find(model.Id);
        if (entry == null)
        {
            return View("Edit");
        }
        entry.Name = model.Name;
        entry.Image = model.Image;
        entry.Note = model.Note;
        _dbContext.SaveChanges();
        
        return RedirectToAction("List");
    }
    
    [HttpGet]
    [ActionName("Delete")]
    public IActionResult Delete(long id)
    {
        var entry = _dbContext.ItemType.Find(id);
        if (entry == null)
        {
            return NotFound();
        }

        var itemType = new ItemTypeViewModel
        {
            Id = entry.Id,
            Name = entry.Name,
            Image = entry.Image,
            Note = entry.Note,
        };

        return View(itemType);
    }
    
    [HttpPost]
    [ActionName("Delete")]
    public IActionResult Delete(ItemTypeEditModel model)
    {
        var entry = _dbContext.ItemType.Find(model.Id);
        if (entry == null)
        {
            return View("Delete");
        }
        _dbContext.ItemType.Remove(entry);
        _dbContext.SaveChanges();
        
        return RedirectToAction("List");
    }

}