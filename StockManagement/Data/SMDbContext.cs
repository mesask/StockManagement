using Microsoft.EntityFrameworkCore;
using StockManagement.Models.Domain;

namespace StockManagement.Data;

public class SMDbContext :  DbContext
{
    public SMDbContext(DbContextOptions<SMDbContext> options) : base( options)
    {
        
    }

    public DbSet<ItemType> ItemType { get; set; }
    public DbSet<Unit> Unit { get; set; }
}