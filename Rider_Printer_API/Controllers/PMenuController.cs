using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qmanja_BAL.Printer_BAL;
using Qmanja_BAL.ViewModels;
using Qmanja_DAL.DBModels;
using Rider_Printer_API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MenuUpdateRecord = Qmanja_DAL.DBModels.MenuUpdateRecord;

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
       
        public async Task<List<MenuCategoriesViewModel>> GetMenuCategoriesAsync([System.Web.Http.FromUri] int businessDetailId)
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
                            MenuItemProperties = new List<MenuItemPropertyViewModel>(),
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

                        if (item.MenuItemProperties != null && item.MenuItemProperties.Count() > 0)
                        {
                            foreach (var menuItem in item.MenuItemProperties)
                            {
                                var propMenu = new MenuItemPropertyViewModel()
                                {
                                    DisplayOrder = menuItem?.DisplayOrder ?? default,
                                    Id = menuItem.Id,
                                    Name = menuItem.Name,
                                    Price = menuItem.Price,
                                    AllowToppings = menuItem.AllowToppings,
                                    DishPropertiesGroupId = menuItem.DishPropertiesGroupId,
                                  //  IsOffline = await _printerMenu.CheckForDisabledItem(menuItem)
                                };

                                obj.MenuItemProperties.Add(propMenu);
                            }
                        }

                        menuCategory.MenuItems.Add(obj);

                    }
                }

                categories.Add(menuCategory);
            }

            return categories;
        }

       
        //[HttpPut("DisableItems")]
        //public async Task<HttpStatusCode> PutDisableItems([System.Web.Http.FromBody] List<DisableItemsViewModel> items)
        //{
        //    if (items == null || items.Count < 1) return HttpStatusCode.BadRequest;
        //    var disabledItems = new List<DisabledItem>();
        //    foreach (var item in items)
        //    {
        //        var disabledItem = new DisabledItem()
        //        {
        //            ItemId = item.ItemId,
        //            ItemType = item.ItemType,
        //            From = DateTime.UtcNow,
        //            To = item.Duration == DisabledItemLife.OneDay ? DateTime.Today : CalculateYears(DateTime.Today)
        //        };
        //        disabledItems.Add(disabledItem);
        //    }
        //    return await _printerMenu.DisableItems(disabledItems);
        //}


       
        //[HttpPut("EnableItems")]
        //public async Task<HttpStatusCode> PutEnableItems([System.Web.Http.FromBody] List<long> items)
        //{
        //    if (items == null || items.Count < 1) return HttpStatusCode.BadRequest;

        //    return await _printerMenu.EnableItems(items);
        //}
        #region Helpers
        private DateTime CalculateYears(DateTime date)
        {
            date.AddYears(5);

            return date;
        }
        #endregion Helpers

        [HttpPut("DisableMenuItems")]
        public async Task<HttpStatusCode> PutDisableMenuItems([System.Web.Http.FromBody] ItemStatusViewModel items)
        {
            if (items == null || items.Id < 1) return HttpStatusCode.BadRequest;
            return await _printerMenu.DisableMenuItems(items);
        }
        [HttpPut("EnableMenuItems")]
        public async Task<HttpStatusCode> PutEnableMenuItems([System.Web.Http.FromBody] ItemStatusViewModel items)
        {
            if (items == null || items.Id < 1) return HttpStatusCode.BadRequest;
            return await _printerMenu.EnableMenuItems(items);
        }
        [HttpPut("DisableMenuProperties")]
        public async Task<HttpStatusCode> PutDisableMenuItemsProp([System.Web.Http.FromBody] ItemStatusViewModel items)
        {
            if (items == null || items.Id < 1) return HttpStatusCode.BadRequest;
            return await _printerMenu.DisablePropertites(items);
        }
        [HttpPut("EnableMenuPropertites")]
        public async Task<HttpStatusCode> PutEnableMenuItemsPropertites([System.Web.Http.FromBody] ItemStatusViewModel items)
        {
            if (items == null || items.Id < 1) return HttpStatusCode.BadRequest;
            return await _printerMenu.EnableMenuProperies(items);
        }

        [HttpGet("MenuUpdateOn")]
        public async Task<HttpStatusCode> MenuUpdateOn([System.Web.Http.FromUri] int businessid)
        {
            return await _printerMenu.MenuUpdate(businessid);
        }
        [HttpGet("GetMenuUpdate")]
        public async Task<List<MenuUpdateRecord>> GetMenuUpdate()
        {
            return await _printerMenu.GetMenuUpdate();
        }


    }
} 
