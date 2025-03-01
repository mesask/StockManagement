using Microsoft.EntityFrameworkCore;
using StockManagement.Models.Domain;

namespace StockManagement.Data;

public class SMDbContext(DbContextOptions<SMDbContext> options) :  DbContext(options)
{
    // public SMDbContext(DbContextOptions<SMDbContext> options) : DbContext(options)
    // {
    //     
    // }

    public DbSet<ItemType> ItemType { get; set; }
    public DbSet<Unit> Unit { get; set; }
    
    public DbSet<Item> Item { get; set; }
}