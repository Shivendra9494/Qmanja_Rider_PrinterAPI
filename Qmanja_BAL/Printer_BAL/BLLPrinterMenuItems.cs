using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class BLLPrinterMenuItems : IBLLPrinterMenuItems
    {
        #region Private Properties
        private readonly QFoodsContext _qFoodsContext;
        private readonly IMapper _mapper;
        #endregion Private Properties

        #region Constructor
        public BLLPrinterMenuItems(QFoodsContext qFoodsContext, IMapper mapper)
        {
            _qFoodsContext = qFoodsContext;
            _mapper = mapper;
        }
        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Return Menu Category Items
        /// </summary>
        /// <param name="bussinessDetailId"></param>
        /// <returns></returns>
        public async Task<List<MenuCategory>> GetMenuItems(int bussinessDetailId)
        {
            var menuItems = await _qFoodsContext.MenuCategories.Where(e => e.BusinessDetailId == bussinessDetailId)
                .Include(e => e.MenuItems)
                .ThenInclude(menuItems => menuItems.MenuItemModels)
                 .Include(f => f.MenuItems)
                .ThenInclude(menuItemsprop => menuItemsprop.MenuItemProperties)
                .Include(g => g.BusinessDetail).ToListAsync();
            return menuItems;



        }

        public async Task<bool> CheckForDisabledItem(MenuItem item)
        {
            var isDisabled = await _qFoodsContext.DisabledItems.Where(i => i.ItemId == item.Id).FirstOrDefaultAsync();
            return isDisabled == null ? false : true;
        }

        public async Task<bool> CheckForDisabledItem(MenuItemModel item)
        {
            var isDisabled = await _qFoodsContext.DisabledItems.Where(i => i.ItemId == item.Id).FirstOrDefaultAsync();
            return isDisabled == null ? false : true;
        }

        /// <summary>
        /// Disable menu items for one day or 5 years
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> DisableItems(List<DisabledItem> items)
        {
            foreach (var item in items)
            {
                var isExists = _qFoodsContext.DisabledItems.Where(i => i.ItemId == item.Id).FirstOrDefault();
                if (isExists == null)
                {
                    _qFoodsContext.DisabledItems.Add(item);
                }
            }

            await _qFoodsContext.SaveChangesAsync();

            return HttpStatusCode.OK;
        }

        /// <summary>
        /// Disable menu items for one day or 5 years
        /// </summary>
        /// <param name="menuitems"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> DisableMenuItems(ItemStatusViewModel menuitems)
        {
            var isExists = _qFoodsContext.MenuItems.Where(i => i.Id == menuitems.Id).FirstOrDefault();
            if (isExists != null)
            {
                isExists.IsDisabled = true;
                isExists.DisabledUpto = menuitems.DisabledUpto;
                _qFoodsContext.MenuItems.Update(isExists);
                _qFoodsContext.SaveChanges();
            }

            return HttpStatusCode.OK;


        }
        /// <summary>
        /// Disable menu properties for one day or 5 years
        /// </summary>
        /// <param name="menuPropertites"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> DisablePropertites(ItemStatusViewModel menuproperties)
        {
            var isExists = _qFoodsContext.MenuItemProperties.Where(i => i.Id == menuproperties.Id).FirstOrDefault();
            if (isExists != null)
            {
                isExists.IsDisabled = true;
                isExists.DisabledUpto = menuproperties.DisabledUpto;
                _qFoodsContext.MenuItemProperties.Update(isExists);
                _qFoodsContext.SaveChanges();
            }

            return HttpStatusCode.OK;


        }


        /// <summary>
        /// Disable menu properties for one day or 5 years
        /// </summary>
        /// <param name="menuPropertites"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> EnableMenuProperies(ItemStatusViewModel menuproperties)
        {
            var isExists = _qFoodsContext.MenuItemProperties.Where(i => i.Id == menuproperties.Id).FirstOrDefault();
            if (isExists != null)
            {
                isExists.IsDisabled = false;
                isExists.DisabledUpto = null;
                _qFoodsContext.MenuItemProperties.Update(isExists);
                _qFoodsContext.SaveChanges();
            }

            return HttpStatusCode.OK;



        }
        /// <summary>
        /// Disable menu properties for one day or 5 years
        /// </summary>
        /// <param name="menuitems"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> EnableMenuItems(ItemStatusViewModel menuitems)
        {

            var isExists = _qFoodsContext.MenuItems.Where(i => i.Id == menuitems.Id).FirstOrDefault();
            if (isExists != null)
            {
                isExists.IsDisabled = false;
                isExists.DisabledUpto = null;
                _qFoodsContext.MenuItems.Update(isExists);
                _qFoodsContext.SaveChanges();
            }

            return HttpStatusCode.OK;


        }
        /// <summary>
        /// Enable menu items
        /// </summary>
        /// <param name="businessid"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> MenuUpdate(int businessid)
        {
            var isExists = await _qFoodsContext.MenuUpdateRecords.Where(i => i.BusinessDetailId == businessid).FirstOrDefaultAsync();
           
           
            if(isExists != null)
            {
                isExists.MenuUpdatedOn = DateTime.UtcNow;
                _qFoodsContext.MenuUpdateRecords.Update(isExists);
                _qFoodsContext.SaveChanges();
            }
            else
            {
                MenuUpdateRecord menu = new MenuUpdateRecord();
                menu.BusinessDetailId = businessid;
                menu.MenuUpdatedOn = DateTime.UtcNow;
                _qFoodsContext.MenuUpdateRecords.Add(menu);
                _qFoodsContext.SaveChanges();
            }
           
           
           
            return HttpStatusCode.OK;
        }
         /// <summary>
        /// Enable menu items
        /// </summary>
     
        /// <returns></returns>
        public async Task<List<MenuUpdateRecord>> GetMenuUpdate()
        {
            var isExists = await _qFoodsContext.MenuUpdateRecords.Where(x => x.BusinessDetailId != 0).ToListAsync();
           
            return isExists;
        }

        #endregion Public Methods
    }

    public enum DisabledItemLife
    {
        OneDay = 0,
        FiveYears = 1
    }
}
