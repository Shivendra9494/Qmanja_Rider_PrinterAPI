using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class AccountSheet
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public DateTime On { get; set; }
        public int BusinessDetailId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsFreezed { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
    }
}
