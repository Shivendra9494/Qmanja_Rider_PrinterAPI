using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class OrderBoost
    {
        public OrderBoost()
        {
            OrderBoostPayments = new HashSet<OrderBoostPayment>();
        }

        public int Id { get; set; }
        public int BusinessDeatilId { get; set; }
        public int BoosterId { get; set; }
        public string Status { get; set; }
        public DateTime? StartedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public string StatusOnStart { get; set; }
        public string StatusOnComplete { get; set; }

        public virtual Cmsuser Booster { get; set; }
        public virtual BusinessDetail BusinessDeatil { get; set; }
        public virtual ICollection<OrderBoostPayment> OrderBoostPayments { get; set; }
    }
}
