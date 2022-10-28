using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class VoucherCode
    {
        public int Id { get; set; }
        public string VoucherCodeText { get; set; }
        public int? VoucherCodeDiscount { get; set; }
        public string VoucherType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int BusinessDetailId { get; set; }
        public string Status { get; set; }
        public int Total { get; set; }
        public int Redeemed { get; set; }
        public int Balance { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
    }
}
