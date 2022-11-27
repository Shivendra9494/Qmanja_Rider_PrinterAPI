using Qmanja_BAL.ViewModels;
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
        //Task<HttpStatusCode> DisableItems(List<DisabledItem> items);
        //Task<HttpStatusCode> EnableItems(List<long> itemsIds);

        Task<HttpStatusCode> EnableMenuItems(ItemStatusViewModel menuitems);
        Task<HttpStatusCode> EnableMenuProperies(ItemStatusViewModel menuItemProperty);
        Task<HttpStatusCode> DisableMenuItems (ItemStatusViewModel menuitems);
        Task<HttpStatusCode> DisablePropertites(ItemStatusViewModel menuItemProperty);
        Task<HttpStatusCode> MenuUpdate(int businessid);
        Task<List<MenuUpdateRecord>> GetMenuUpdate();
    }
}
