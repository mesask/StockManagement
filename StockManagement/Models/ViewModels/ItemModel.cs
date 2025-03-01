namespace StockManagement.Models.ViewModels;

public class ItemModel
{
    public string Code { get; set; }
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public decimal Price { get; set; }
    public long ItemTypeId { get; set; }
    public long UnitId { get; set; }
    public string Image { get; set; }
    public bool IsStock { get; set; } = false;
    public string Note { get; set; }
}

public class ItemListModel : ItemModel
{
    public long Id { get; set; }
    public string ItemTypeName { get; set; }
    public string UnitName { get; set; }
}

public class ItemViewModel : ItemModel
{
    public long Id { get; set; }
}

public class ItemEditModel : ItemModel
{
    public long Id { get; set; }
}

public class ItemAddModel : ItemModel{}