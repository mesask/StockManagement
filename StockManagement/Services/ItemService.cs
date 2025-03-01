// using AutoMapper;
// using Microsoft.EntityFrameworkCore;
// using StockManagement.Data;
// using StockManagement.Models.Domain;
// using StockManagement.Models.ViewModels;

// namespace StockManagement.Services;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StockManagement.Data;
using StockManagement.Models.Domain;
using StockManagement.Models.ViewModels;

namespace StockManagement.Services;

public class ItemService(SMDbContext db, IMapper mapper)
{
    public async Task<List<ItemListModel>> SearchAsync(string searchQuery, string sortBy, string sortDirection, int pageNumber = 1, int pageSize = 3)
    {
        var entries = (from i in db.Item
            join it in db.ItemType on i.ItemTypeId equals it.Id
                into itg from it in itg.DefaultIfEmpty()
            join u in db.Unit on i.UnitId equals u.Id
                into ug from u in ug.DefaultIfEmpty()
            select new ItemListModel
            {
                Id = i.Id,
                Code = i.Code,
                Name = i.Name,
                Cost = i.Cost,
                Price = i.Price,
                ItemTypeId = i.ItemTypeId,
                ItemTypeName = it.Name,
                UnitId = i.UnitId,
                UnitName = u.Name,
                Image = i.Image,
                IsStock = i.IsStock,
                Note = i.Note

            }).AsQueryable();
        
        // filter
        
        if(!string.IsNullOrEmpty(searchQuery))
        {
            entries = entries.Where(x => x.Name.Contains(searchQuery));
        }
        
        // sort

        if (string.IsNullOrWhiteSpace(sortBy) == false)
        {
            var isDesc = string.Equals(sortDirection, "Desc", StringComparison.OrdinalIgnoreCase);
            if (string.Equals(sortBy, "Name", StringComparison.OrdinalIgnoreCase))
            {
                entries = isDesc ? entries.OrderByDescending(x => x.Name) : entries.OrderBy(x => x.Name);
            }
        }
        
        // pagination 
        var skipRecords = (pageNumber - 1) * pageSize;
        entries = entries.Skip(skipRecords).Take(pageSize);
        
        return mapper.Map<List<ItemListModel>>(await entries.ToListAsync());
    }

    public async Task<int> CountAsync()
    {
        return await db.Item.CountAsync();
    }
    
    // public async Task<ItemViewModel> FindAsync(long id)
    // {
    //     var entry = await (from i in db.Item where i.Id == id
    //         join it in db.ItemType on i.ItemTypeId equals it.Id
    //             into itg from it in itg.DefaultIfEmpty()
    //         join u in db.Unit on i.UnitId equals u.Id
    //             into ug from u in ug.DefaultIfEmpty()
    //         select new ItemViewModel
    //         {
    //             Id = i.Id,
    //             Code = i.Code,
    //             Name = i.Name,
    //             Cost = i.Cost,
    //             Price = i.Price,
    //             ItemTypeId = i.ItemTypeId,
    //             ItemTypeName = it.Name,
    //             UnitId = i.UnitId,
    //             UnitName = u.Name,
    //             Image = i.Image,
    //             IsStock = i.IsStock,
    //             Note = i.Note
    //         }).FirstOrDefaultAsync();
    //     return mapper.Map<ItemViewModel>(entry);
    //
    
    
    public async Task<ItemViewModel> AddAsync(ItemAddModel model)
    {
        
        var entry = mapper.Map<Item>(model);
        await db.Item.AddAsync(entry);
        await db.SaveChangesAsync();
        return mapper.Map<ItemViewModel>(entry);
        
    }
}

// using AutoMapper;
// using Microsoft.EntityFrameworkCore;
// using StockManagement.Data;
// using StockManagement.Models.Domain;
// using StockManagement.Models.ViewModels;
//
// namespace StockManagement.Services;
//
// public class ItemService(SMDbContext db, IMapper mapper)
// {
//     public async Task<List<ItemListModel>> SearchASync(string searchQuery)
//     {
//         var entries = (from i in db.Item
//             join it in db.ItemType on i.ItemTypeId equals it.Id
//             join u in db.Unit on i.UnitId equals u.Id
//             into ug from u in ug.DefaultIfEmpty()
//             select new ItemListModel
//             {
//                 Id = i.Id,
//                 Name = i.Name,
//                 Cost = i.Cost,
//                 Price = i.Price,
//                 ItemTypeId = i.ItemTypeId,
//                 ItemTypeName = it.Name,
//                 UnitId = i.UnitId,
//                 UnitName = u.Name,
//                 Image = i.Image,
//                 IsStock = i.IsStock,
//                 Note = i.Note
//             }).AsQueryable();
//         // filter
//
//         if (!string.IsNullOrEmpty(searchQuery))
//         {
//             entries = entries.Where(x => x.Name.Contains(searchQuery));
//         }
//         
//         return mapper.Map<List<ItemListModel>>(await entries.ToListAsync());
//     }
//     public async Task<ItemViewModel> AddASync(ItemAddModel model)
//     {
//         var entry = mapper.Map<Item>(model);
//         await db.Item.AddAsync(entry);
//         await db.SaveChangesAsync();
//         return mapper.Map<ItemViewModel>(entry);
//     }
//     
//     // public async Task<ItemViewModel> FindAsync(long id)
//     // {
//     //     var entry = await db.Item.FirstOrDefaultAsync(x => x.Id == id);
//     //     if (entry == null)
//     //     {
//     //         throw new Exception("Item not found !!!");
//     //     }
//     //
//     //     return mapper.Map<ItemViewModel>(entry);
//     // }
//
//     // public async Task<ItemViewModel> FindAsync(long id)
//     // {
//     //     var entry = await (from i in db.Item where i.Id == id
//     //         join it in db.ItemType on i.ItemTypeId equals it.Id
//     //         into itg from it in itg.DefaultIfEmpty()
//     //         join u in db.Unit on i.UnitId equals u.Id
//     //         into ug from u in ug.DefaultIfEmpty()
//     //         select new ItemListModel
//     //         {
//     //             Id = i.Id,
//     //             Name = i.Name,
//     //             Cost = i.Cost,
//     //             Price = i.Price,
//     //             ItemTypeId = i.ItemTypeId,
//     //             ItemTypeName = it.Name,
//     //             UnitId = i.UnitId,
//     //             UnitName = u.Name,
//     //             Image = i.Image,
//     //             IsStock = i.IsStock,
//     //             Note = i.Note
//     //         }).AsQueryable();
//     // }
//
//     // public async Task<ItemViewModel> UpdateOrEditAsync(ItemEditModel model)
//     // {
//     //     var entry = await db.Item.FindAsync(model.Id);
//     //     if (entry == null)
//     //     {
//     //         throw new Exception("Item not found !!!");
//     //     }
//     //
//     //     entry.Code = model.Code;
//     //     entry.Name = model.Name;
//     //     entry.Cost = model.Cost;
//     //     entry.Price = model.Price;
//     //     entry.UnitId = model.UnitId;
//     //     entry.ItemTypeId = model.ItemTypeId;
//     //     entry.Image = model.Image;
//     //     entry.IsStock = model.IsStock;
//     //     entry.Note = model.Note;
//     //
//     //     await db.SaveChangesAsync();
//     //     return mapper.Map<ItemViewModel>(entry);
//     // }
//
//     
//     
// }
//
// // using AutoMapper;
// // using StockManagement.Data;
// // using StockManagement.Models.Domain;
// // using StockManagement.Models.ViewModels;
// //
// // namespace StockManagement.Services;
// //
// // public class ItemService(SMDbContext db, IMapper mapper)
// // {
// //     public async Task<ItemListModel>> SearchAsync()
// //     {
// //         var entries = from i in db.Item
// //             join it in db.ItemType on i.ItemTypeId equals it.Id equals it.Id
// //             join u in db.Unit on i.UnitId equals u.Id
// //             select new ItemListModel
// //             {
// //                 Id = i.UnitId,
// //                 Name = i.Name,
// //                 Cost = i.Cost,
// //                 Price = i.Price,
// //                 
// //             }
// //     }
// //     
// //     public async Task<ItemViewModel> AddAsync(ItemAddModel model);
// //     {
// //         var entry = mapper.Map<Item>(model);
// //         await db.Item.AddAsync(entry);
// //         await db.SaveChangesAsync();
// //         return mapper.Map<ItemViewModel>(entry);
// //     }
// // }
