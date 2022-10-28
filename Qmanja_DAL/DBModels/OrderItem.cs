using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class OrderItem
    {
        public OrderItem()
        {
            OrderModels = new HashSet<OrderModel>();
        }

        public int Id { get; set; }
        public int? Qta { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }
        public string ToppingIds { get; set; }
        public string DishPropertiesIds { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
        public int? MenuItemPropertyId { get; set; }
        public string ItemType { get; set; }
        public string Name { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<OrderModel> OrderModels { get; set; }
    }
}
