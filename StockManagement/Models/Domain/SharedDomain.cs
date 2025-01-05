namespace StockManagement.Models.Domain;

public class SharedDomain
{
    public long Id { get; set; }
    public bool IsActive { get; set; } = true;
}

public class MAX_LENGHT
{
    public const int NAME = 500;
    public const int IMAGE = 500;
    public const int NOTE = 5000;
}