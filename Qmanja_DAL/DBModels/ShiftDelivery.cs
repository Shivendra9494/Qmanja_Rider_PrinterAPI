using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class ShiftDelivery
    {
        public int Id { get; set; }
        public TimeSpan OpenFrom { get; set; }
        public TimeSpan OpenTo { get; set; }
        public int DayOfWeek { get; set; }
        public string ShiftType { get; set; }
        public int BusinessDetailId { get; set; }
        public bool Closed { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
    }
}
