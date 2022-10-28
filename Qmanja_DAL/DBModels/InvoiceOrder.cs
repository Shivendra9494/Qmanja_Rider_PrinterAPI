using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class InvoiceOrder
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string OrderNo { get; set; }
        public string Type { get; set; }
        public string Cash { get; set; }
        public string Card { get; set; }
        public string Total { get; set; }
        public int InvoiceId { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
