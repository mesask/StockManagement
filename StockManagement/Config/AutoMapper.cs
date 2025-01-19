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
        // CreateMap<ItemType,ItemTypeEditModel>().ReverseMap();
        //CreateMap<ItemType,ItemTypeDeleteModel>().ReverseMap();
        CreateMap<Unit, UnitListModel>().ReverseMap();
        CreateMap<Unit, UnitAddModel>().ReverseMap();
        CreateMap<Unit, UnitViewModel>().ReverseMap();
    }
}