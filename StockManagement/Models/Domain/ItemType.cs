using System.ComponentModel.DataAnnotations;

namespace StockManagement.Models.Domain;

public class ItemType : SharedDomain
{
    [MaxLength(MAX_LENGHT.NAME)]
    public string Name { get; set; }
    [MaxLength(MAX_LENGHT.IMAGE)]
    public string Image { get; set; }
    [MaxLength(MAX_LENGHT.NOTE)]
    public string Note { get; set; }
}