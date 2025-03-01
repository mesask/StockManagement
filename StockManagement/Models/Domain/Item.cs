using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockManagement.Models.Domain;

public class Item : SharedDomain
{
    [MaxLength(MAX_LENGHT.NAME)]
    public string Code { get; set; }
    [MaxLength(MAX_LENGHT.NAME)]
    public string Name { get; set; }
    [Column(TypeName = "decimal(16, 6)")]
    public decimal Cost { get; set; }
    [Column(TypeName = "decimal(16, 6)")]
    public decimal Price { get; set; }
    public long ItemTypeId { get; set; }
    public long UnitId { get; set; }
    [MaxLength(MAX_LENGHT.NAME)]
    public string Image { get; set; }

    public bool IsStock { get; set; } = false;
    [MaxLength(MAX_LENGHT.NOTE)]
    public string Note { get; set; }
}