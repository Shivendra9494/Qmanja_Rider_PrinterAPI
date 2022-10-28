using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class MenuDishProperty
    {
        public int Id { get; set; }
        public string DishProperty { get; set; }
        public double? DishPropertyPrice { get; set; }
        public int? DisplayoOder { get; set; }
        public int MenuDishPropertiesGroupId { get; set; }

        public virtual MenuDishPropertiesGroup MenuDishPropertiesGroup { get; set; }
    }
}
