using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            MenuItemModels = new HashSet<MenuItemModel>();
            MenuItemProperties = new HashSet<MenuItemProperty>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Vegetarian { get; set; }
        public short? Spicyness { get; set; }
        public decimal? Price { get; set; }
        public string Photo { get; set; }
        public string AllowToppings { get; set; }
        public string DishPropertyGroupId { get; set; }
        public int? DisplayOrder { get; set; }
        public int MenuCategoryId { get; set; }
        public string DiscountOff { get; set; }
        public string ImagePath { get; set; }
        public bool? ContainEggs { get; set; }
        public bool? IsRecommended { get; set; }
        public bool? IsChefSpecial { get; set; }
        public bool? IsMustTry { get; set; }
        public bool? IsSeasonal { get; set; }
        public int? Discount { get; set; }
        public decimal? OriginalPrice { get; set; }

        public virtual MenuCategory MenuCategory { get; set; }
        public virtual ICollection<MenuItemModel> MenuItemModels { get; set; }
        public virtual ICollection<MenuItemProperty> MenuItemProperties { get; set; }
    }
}
