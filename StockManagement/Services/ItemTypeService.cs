using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StockManagement.Data;
using StockManagement.Models.Domain;
using StockManagement.Models.ViewModels;

namespace StockManagement.Services;

public class ItemTypeService(SMDbContext db, IMapper mapper)
{
    public List<ItemTypeListModel> SearchAsync()
    {
        // var entries = _dbContext.ItemType.ToList();
        // return View(_mapper.Map<List<ItemTypeListModel>>(entries));
        var entries = db.ItemType.ToList();
        return mapper.Map<List<ItemTypeListModel>>(entries);
    }

    public ItemTypeViewModel AddAsync(ItemTypeAddModel model)
    {
        var entry = mapper.Map<ItemType>(model);
        db.ItemType.Add(entry);
        db.SaveChanges();
        return mapper.Map<ItemTypeViewModel>(entry);
    }
    
    // async and await , Task 

    public async Task<ItemTypeViewModel> FindAsync(long id)
    {
        var entry = await db.ItemType.FirstOrDefaultAsync(x => x.Id == id);
        if (entry == null)
        {
            throw new Exception("Item type not found !!!");
        }
        
        return mapper.Map<ItemTypeViewModel>(entry);
        
        // var itemType = new ItemTypeViewModel
        // {
        //     Id = entry.Id,
        //     Name = entry.Name,
        //     Image = entry.Image,
        //     Note = entry.Note,
        // };
        // return mapper.Map<ItemTypeViewModel>(entry);
        //return View(itemType);
    }
    // public ItemTypeViewModel EditAsync(ItemTypeEditModel model)
    // {
    //     var entry = db.ItemType.Find(model.Id);
    //     if (entry == null)
    //     {
    //         throw new Exception("Item Type not found!");
    //     }
    //     entry.Name = model.Name;
    //     entry.Image = model.Image;
    //     entry.Note = model.Note;
    //     db.SaveChanges();
    //     return mapper.Map<ItemTypeViewModel>(entry);
    // }
    public async Task<ItemTypeViewModel> UpdateOrEditAsync(ItemTypeEditModel model)
    {
        var entry = await db.ItemType.FindAsync(model.Id);
        if (entry == null)
        {
            throw new Exception("Item type not found !!!");
        }
        entry.Name = model.Name;
        entry.Image = model.Image;
        entry.Note = model.Note;
        await db.SaveChangesAsync();
        return mapper.Map<ItemTypeViewModel>(entry);
    }

    public async Task<ItemTypeViewModel> DeleteAsync(long id)
    {
        var entry = await db.ItemType.FindAsync(id);
        if (entry == null)
        {
            throw new Exception("Item type not found !!!");
        }
        db.ItemType.Remove(entry);
        await db.SaveChangesAsync();
        return mapper.Map<ItemTypeViewModel>(entry);
    }
    // public ItemTypeViewModel DeleteAsync(ItemTypeEditModel model)
    // {
    //     // var entry = db.ItemType.FirstOrDefault(x => x.Id == model.Id);
    //     var entry = db.ItemType.Find(model.Id);
    //     if (entry == null)
    //     {
    //         throw new Exception("Item Type not found!");
    //     }
    //     
    //     // var itemType = new ItemTypeViewModel
    //     // {
    //     //     Id = entry.Id,
    //     //     Name = entry.Name,
    //     //     Image = entry.Image,
    //     //     Note = entry.Note,
    //     // };
    //     db.ItemType.Remove(entry);
    //     db.SaveChanges();
    //     return mapper.Map<ItemTypeViewModel>(entry);
    // }
}