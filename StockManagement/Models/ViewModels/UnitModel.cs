namespace StockManagement.Models.ViewModels;

public class UnitModel
{
    public string Name { get; set; }
    public string Note { get; set; }
}

public class UnitListModel : UnitModel
{
    public long Id { get; set; }
}

public class UnitViewModel : UnitModel
{
    public long Id { get; set; }
}

public class UnitEditModel : UnitModel
{
    public long Id { get; set; }
}

public class UnitAddModel : UnitModel;