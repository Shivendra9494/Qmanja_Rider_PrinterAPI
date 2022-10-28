using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class OrderBoostPaymentTerm
    {
        public int Id { get; set; }
        public int MinOrder { get; set; }
        public int? MaxOrder { get; set; }
        public int Amount { get; set; }
    }
}
