using Qmanja_DAL.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Qmanja_BAL.Printer_BAL
{
    public interface IBLLPrinterMenuItems
    {
        Task<List<MenuCategory>> GetMenuItems(int bussinessDetailId);
        Task<bool> CheckForDisabledItem(MenuItem item);
        Task<bool> CheckForDisabledItem(MenuItemModel item);
        Task<HttpStatusCode> DisableItems(List<DisabledItem> items);
        Task<HttpStatusCode> EnableItems(List<long> itemsIds);
    }
}
