using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class OrderModel
    {
        public OrderModel()
        {
            OrderModelExtras = new HashSet<OrderModelExtra>();
        }

        public int Id { get; set; }
        public int DisplayOrder { get; set; }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public string Qty { get; set; }
        public decimal? Price { get; set; }
        public int OrderItemId { get; set; }
        public int? OptionId { get; set; }

        public virtual OrderItem OrderItem { get; set; }
        public virtual ICollection<OrderModelExtra> OrderModelExtras { get; set; }
    }
}
