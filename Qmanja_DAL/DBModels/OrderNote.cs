using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class OrderNote
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Note { get; set; }
        public DateTime TimeStamp { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Cmsuser User { get; set; }
    }
}
