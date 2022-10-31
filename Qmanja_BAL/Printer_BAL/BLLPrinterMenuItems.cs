using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
                .ThenInclude(menuItems => menuItems.MenuItem.MenuItemProperties)
                .Include(e => e.BusinessDetail).ToListAsync();
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
        /// Enable menu items
        /// </summary>
        /// <param name="itemsIds"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> EnableItems(List<long> itemsIds)
        {
            foreach (var itemId in itemsIds)
            {
                var isExists = await _qFoodsContext.DisabledItems.Where(i => i.ItemId == itemId).FirstOrDefaultAsync();
                if (isExists != null)
                {
                    _qFoodsContext.DisabledItems.Remove(isExists);
                    _qFoodsContext.SaveChanges();
                }
            }

            return HttpStatusCode.OK;
        }

        #endregion Public Methods
    }

    public enum DisabledItemLife
    {
        OneDay = 0,
        FiveYears = 1
    }
}
