using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class MenuDishPropertiesGroup
    {
        public MenuDishPropertiesGroup()
        {
            MenuDishProperties = new HashSet<MenuDishProperty>();
        }

        public int Id { get; set; }
        public string DishPropertyGroup { get; set; }
        public string DishPropertyPriceType { get; set; }
        public bool DishPropertyRequired { get; set; }
        public string DishPropertyGroupDisplayName { get; set; }
        public int BusinessDetailId { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
        public virtual ICollection<MenuDishProperty> MenuDishProperties { get; set; }
    }
}
