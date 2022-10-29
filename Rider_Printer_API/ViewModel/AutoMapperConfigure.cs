using AutoMapper;
using Qmanja_BAL.Printer_BAL;
using Qmanja_DAL.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rider_Printer_API.ViewModel
{
    public class AutoMapperConfigure : Profile
    {
        public AutoMapperConfigure()
        {
            CreateMap<MenuCategory, MenuCategoriesViewModel>()
                 .ForMember(dest => dest.MenuItems, opt => opt.MapFrom(src => src.MenuItems));

            CreateMap<MenuItem, MenuItemsViewModel>()
                .ForMember(dest => dest.MenuItemModels, opt => opt.MapFrom(src => src.MenuItemModels))
                .ForMember(dest => dest.MenuItemProperties, opt => opt.MapFrom(src => src.MenuItemProperties));

            CreateMap<MenuItemModel, MenuItemViewModel>();

            CreateMap<MenuItemProperty, MenuItemPropertyViewModel>();
        }
    }
}
