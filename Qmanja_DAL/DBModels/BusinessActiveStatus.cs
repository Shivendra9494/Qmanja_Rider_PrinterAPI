using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class BusinessActiveStatus
    {
        public int Id { get; set; }
        public int BusinessDetailId { get; set; }
        public DateTime DateFrom { get; set; }
        public string Status { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
    }
}
