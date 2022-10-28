using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class DeliveryAreaInfo
    {
        public int Id { get; set; }
        public string PPrefix { get; set; }
        public string PPostfix { get; set; }
        public decimal? MinimumOrder { get; set; }
        public decimal? DeliveryFee { get; set; }
        public string FreeOrder { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIp { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedByIp { get; set; }
        public string Description { get; set; }
        public int BusinessDetailId { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
    }
}
