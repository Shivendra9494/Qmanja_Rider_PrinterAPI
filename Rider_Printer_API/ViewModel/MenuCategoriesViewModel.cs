using Qmanja_DAL.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rider_Printer_API.ViewModel
{
    public class MenuCategoriesViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public int BusinessDetailID { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
        public virtual IList<MenuItemsViewModel> MenuItems { get; set; } // all categories for specific bussiness
    }
    public class MenuItemsViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Vegetarian { get; set; }
        public Nullable<short> Spicyness { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Photo { get; set; }
        public string AllowToppings { get; set; }
        public string DishPropertyGroupId { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public int MenuCategoryID { get; set; }
        public string DiscountOff { get; set; }

        public bool IsOffline { get; set; }
        public IList<MenuItemViewModel> MenuItemModels { get; set; }
        public IList<MenuItemPropertyViewModel> MenuItemProperties { get; set; }
    }

    public class MenuItemViewModel
    {
        public int Id { get; set; }
        public int DisplayOrder { get; set; }
        public string ItemType { get; set; }
        public int ItemId { get; set; }
        public int MenuItemId { get; set; }
        public bool IsOffline { get; set; }
    }

    public class MenuItemPropertyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> IdMenuItem { get; set; }
        public string AllowToppings { get; set; }
        public string DishPropertiesGroupId { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public virtual MenuItemViewModel MenuItem { get; set; }
    }
}
