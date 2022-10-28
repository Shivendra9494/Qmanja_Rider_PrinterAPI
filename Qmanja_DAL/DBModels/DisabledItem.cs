using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class DisabledItem
    {
        public int Id { get; set; }
        public string ItemType { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int ItemId { get; set; }
    }
}
