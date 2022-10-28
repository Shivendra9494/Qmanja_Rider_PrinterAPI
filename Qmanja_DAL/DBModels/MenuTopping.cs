using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class MenuTopping
    {
        public int Id { get; set; }
        public string Topping { get; set; }
        public double? ToppingPrice { get; set; }
        public int MenuToppingsGroupId { get; set; }
        public int? DisplayOrder { get; set; }

        public virtual MenuToppingsGroup MenuToppingsGroup { get; set; }
    }
}
