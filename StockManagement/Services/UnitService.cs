using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StockManagement.Data;
using StockManagement.Models.Domain;
using StockManagement.Models.ViewModels;

namespace StockManagement.Services;

public class UnitService(SMDbContext db, IMapper mapper)
{
    public async Task<List<UnitListModel>> SearchAsync()
    {
        var entries = await db.Unit.ToListAsync();
        return mapper.Map<List<UnitListModel>>(entries);
    }

    public async Task<UnitViewModel> AddAsync(UnitAddModel model)
    {
        var entry = mapper.Map<Unit>(model);
        await db.Unit.AddAsync(entry);
        await db.SaveChangesAsync();
        return mapper.Map<UnitViewModel>(entry);
    }

    public async Task<UnitViewModel> FindAsync(long id)
    {
        var entry = await db.Unit.FirstOrDefaultAsync(x => x.Id == id);
        if (entry == null)
        {
            throw new Exception("Unit not found !!!");
        }
        
        return mapper.Map<UnitViewModel>(entry);
    }

    public async Task<UnitViewModel> UpdateOrEditAsync(UnitEditModel model)
    {
        var entry = await db.Unit.FindAsync(model.Id);
        if (entry == null)
        {
            throw new Exception("Unit not found !!!");
        }
        entry.Name = model.Name;
        entry.Note = model.Note;
        // entry.Description = model.Description; // Assuming `Unit` has a `Description` field
        await db.SaveChangesAsync();
        return mapper.Map<UnitViewModel>(entry);
    }

    public async Task<UnitViewModel> DeleteAsync(long id)
    {
        var entry = await db.Unit.FindAsync(id);
        if (entry == null)
        {
            throw new Exception("Unit not found !!!");
        }
        db.Unit.Remove(entry);
        await db.SaveChangesAsync();
        return mapper.Map<UnitViewModel>(entry);
    }
}