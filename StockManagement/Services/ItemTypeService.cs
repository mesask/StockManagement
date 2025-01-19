using AutoMapper;
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
}