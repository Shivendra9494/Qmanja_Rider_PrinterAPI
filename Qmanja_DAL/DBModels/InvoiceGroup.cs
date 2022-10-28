using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class InvoiceGroup
    {
        public InvoiceGroup()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Status { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string ShowDay { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
