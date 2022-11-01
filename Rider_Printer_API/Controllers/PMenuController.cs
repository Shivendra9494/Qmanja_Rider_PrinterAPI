using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qmanja_BAL.Printer_BAL;
using Rider_Printer_API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

using Microsoft.Extensions.Logging;
using System.Net;
using Qmanja_DAL.DBModels;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;

namespace Rider_Printer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PMenuController : ControllerBase
    {

         private readonly IBLLPrinterMenuItems _printerMenu;
        //  BLLPrinterMenuItems _printerMenu = new BLLPrinterMenuItems();

        public PMenuController(IBLLPrinterMenuItems printerMenu)
        {
            _printerMenu = printerMenu;
        }


        [HttpGet("MenuCategories")]
       
        public async Task<List<MenuCategoriesViewModel>> GetMenuCategoriesAsync([FromUri] int businessDetailId)
        {
            if (businessDetailId < 1) throw new Exception("Invalid Id!");
            var menuCategories = await _printerMenu.GetMenuItems(businessDetailId);

            var categories = new List<MenuCategoriesViewModel>();

            foreach (var category in menuCategories)
            {
                var menuCategory = new MenuCategoriesViewModel()
                {
                    BusinessDetailID = category.BusinessDetailId,
                    DisplayOrder = category.DisplayOrder,
                    Name = category.Name,
                    Description = category.Description,
                    ID = category.Id,
                    MenuItems = new List<MenuItemsViewModel>()
                };

                if (category.MenuItems != null && category.MenuItems.Count() > 0)
                {
                    // Check for Disabled Menu Items
                    foreach (var item in category.MenuItems)
                    {
                        // Top Level Menu Item
                        var obj = new MenuItemsViewModel()
                        {
                            MenuCategoryID = category.Id,
                            DisplayOrder = item.DisplayOrder,
                            Name = item.Name,
                            Description = item.Description,
                            Price = item.Price,
                            DiscountOff = item.DiscountOff,
                            Id = item.Id,
                            MenuItemModels = new List<MenuItemViewModel>(),
                            IsOffline = await _printerMenu.CheckForDisabledItem(item)
                        };

                        // Child Level Menu Item
                        // Check for disabled
                        if (item.MenuItemModels != null && item.MenuItemModels.Count() > 0)
                        {
                            foreach (var menuItem in item.MenuItemModels)
                            {
                                var childMenu = new MenuItemViewModel()
                                {
                                    DisplayOrder = menuItem.DisplayOrder,
                                    Id = menuItem.Id,
                                    ItemId = menuItem.ItemId,
                                    MenuItemId = menuItem.MenuItemId,
                                    ItemType = menuItem.ItemType,
                                   IsOffline = await _printerMenu.CheckForDisabledItem(menuItem)
                                };

                                obj.MenuItemModels.Add(childMenu);
                            }
                        }

                        menuCategory.MenuItems.Add(obj);

                    }
                }

                categories.Add(menuCategory);
            }

            return categories;
        }

        [Microsoft.AspNetCore.Mvc.HttpPut("DisableItems")]
        public async Task<HttpStatusCode> PutDisableItems([System.Web.Http.FromBody] List<DisableItemsViewModel> items)
        {
            if (items == null || items.Count < 1) return HttpStatusCode.BadRequest;

            var disabledItems = new List<DisabledItem>();

            foreach (var item in items)
            {
                var disabledItem = new DisabledItem()
                {
                    ItemId = item.ItemId,
                    ItemType = item.ItemType,
                    From = DateTime.UtcNow,
                    To = item.Duration == DisabledItemLife.OneDay ? DateTime.Today : CalculateYears(DateTime.Today)
                };

                disabledItems.Add(disabledItem);
            }

            return await _printerMenu.DisableItems(disabledItems);
        }


     
        [Microsoft.AspNetCore.Mvc.HttpPut("EnableItems")]
        public async Task<HttpStatusCode> PutEnableItems([System.Web.Http.FromBody] List<long> items)
        {
            if (items == null || items.Count < 1) return HttpStatusCode.BadRequest;

            return await _printerMenu.EnableItems(items);
        }
        #region Helpers
        private DateTime CalculateYears(DateTime date)
        {
            date.AddYears(5);

            return date;
        }
        #endregion Helpers
    }
} 
