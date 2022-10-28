using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class DomainSuccessRecord
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public int ItemCount { get; set; }
        public int OrderId { get; set; }
        public int Total { get; set; }
        public string Domain { get; set; }
        public int BusinessId { get; set; }
        public bool IsRenew { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual BusinessDetail Business { get; set; }
    }
}
