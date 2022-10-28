using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class MenuItemProperty
    {
        public MenuItemProperty()
        {
            MenuItemPropertyModels = new HashSet<MenuItemPropertyModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? IdMenuItem { get; set; }
        public string AllowToppings { get; set; }
        public string DishPropertiesGroupId { get; set; }
        public int? DisplayOrder { get; set; }
        public int? Discount { get; set; }
        public decimal? OriginalPrice { get; set; }
        public string DiscountOffer { get; set; }

        public virtual MenuItem IdMenuItemNavigation { get; set; }
        public virtual ICollection<MenuItemPropertyModel> MenuItemPropertyModels { get; set; }
    }
}
