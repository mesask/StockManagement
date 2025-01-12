using Microsoft.AspNetCore.Mvc;
using StockManagement.Data;
using StockManagement.Models.Domain;
using StockManagement.Models.ViewModels;

namespace StockManagement.Controllers;

public class ItemTypeController : Controller
{
    private readonly SMDbContext _dbContext;
    public ItemTypeController(SMDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    [ActionName("List")]
    public IActionResult List()
    {
        var entries = _dbContext.ItemType.ToList();
        var itemTypes = new List<ItemTypeListModel>();
        foreach (var entry in entries)
        {
            var itemType = new ItemTypeListModel
            {
                Id = entry.Id,
                Name = entry.Name,
                Image = entry.Image,
                Note = entry.Note,
            };
            itemTypes.Add(itemType);
        }
        return View(itemTypes);
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
            var itemType = new ItemType
            {
                Name = model.Name,
                Image = model.Image,
                Note = model.Note,
            };
            _dbContext.ItemType.Add(itemType);
            _dbContext.SaveChanges();
            return RedirectToAction("List");
        }
    }