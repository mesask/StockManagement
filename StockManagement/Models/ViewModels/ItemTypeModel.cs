namespace StockManagement.Models.ViewModels;

public class ItemTypeModel
{
    public string Name { get; set; }
    public string Image { get; set; }
    public string Note { get; set; }
}

public class ItemTypeListModel : ItemTypeModel
{
    public long Id { get; set; }
}

public class ItemTypeViewModel : ItemTypeModel
{
    public long Id { get; set; }
}

public class ItemTypeEditModel : ItemTypeModel
{
    public long Id { get; set; }
}

public class ItemTypeAddModel : ItemTypeModel{}

