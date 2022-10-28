using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class OpenStatus
    {
        public int Id { get; set; }
        public bool IsOpen { get; set; }
        public DateTime? DateOn { get; set; }
        public int BusinessDetailId { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
    }
}
