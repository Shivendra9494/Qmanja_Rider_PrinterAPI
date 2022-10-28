using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class OrderBoostPayment
    {
        public int Id { get; set; }
        public int OrderBoostId { get; set; }
        public int Amount { get; set; }
        public DateTime PaidOn { get; set; }
        public DateTime StartedFrom { get; set; }
        public DateTime EndedOn { get; set; }
        public int AverageOrders { get; set; }

        public virtual OrderBoost OrderBoost { get; set; }
    }
}
