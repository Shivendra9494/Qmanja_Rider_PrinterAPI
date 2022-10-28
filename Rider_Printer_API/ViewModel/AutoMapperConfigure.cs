using AutoMapper;
using Qmanja_BAL.Printer_BAL;
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
            //CreateMap<MenuCategoriesViewModel, BLLPrinterMenuItems>(MemberList.None);
            //CreateMap<Account, AccountViewModel>(MemberList.None)
            //    .ForMember(des => des.Department, opt => opt.MapFrom(src => src.Departments.DepartmentName));

            //CreateMap<DepartmentViewModel, Department>(MemberList.None);
            //CreateMap<Department, DepartmentViewModel>(MemberList.None);
        }
    }
}
