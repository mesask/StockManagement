using AutoMapper;
using StockManagement.Models.Domain;
using StockManagement.Models.ViewModels;

namespace StockManagement.Config;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<ItemType,ItemTypeListModel>().ReverseMap();
        CreateMap<ItemType,ItemTypeAddModel>().ReverseMap();
        CreateMap<ItemType,ItemTypeViewModel>().ReverseMap();
    }
}