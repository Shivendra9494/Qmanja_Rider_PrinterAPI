using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class OrderModelExtra
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Qty { get; set; }
        public int DisplayOrder { get; set; }
        public decimal? Price { get; set; }
        public int OrderModelId { get; set; }
        public int? ExtraId { get; set; }

        public virtual OrderModel OrderModel { get; set; }
    }
}
