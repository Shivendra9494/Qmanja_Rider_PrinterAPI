using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public double OldBalance { get; set; }
        public double NewBalance { get; set; }
        public double Amount { get; set; }
        public DateTime On { get; set; }
        public string Description { get; set; }
        public int BusinessDetailId { get; set; }
        public int? InvoiceId { get; set; }
        public bool WithTax { get; set; }
        public double Vat { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
