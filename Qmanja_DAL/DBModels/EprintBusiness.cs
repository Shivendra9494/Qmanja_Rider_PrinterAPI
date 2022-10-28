using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class EprintBusiness
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public DateTime StartFrom { get; set; }
        public DateTime EndOn { get; set; }
        public int NumbersOfOrders { get; set; }
        public string Status { get; set; }
        public bool FreePrinter { get; set; }
    }
}
