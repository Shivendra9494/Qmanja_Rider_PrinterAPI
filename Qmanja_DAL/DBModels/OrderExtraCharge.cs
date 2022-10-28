using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class OrderExtraCharge
    {
        public int Id { get; set; }
        public string ChargeName { get; set; }
        public double Amount { get; set; }
        public int OrderId { get; set; }
        public bool? AddOnDiscount { get; set; }
    }
}
