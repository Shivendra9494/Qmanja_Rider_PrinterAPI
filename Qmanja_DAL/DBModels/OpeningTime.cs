using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class OpeningTime
    {
        public int Id { get; set; }
        public int? DayOfWeek { get; set; }
        public DateTime? HourFrom { get; set; }
        public DateTime? HourTo { get; set; }
        public string Delivery { get; set; }
        public string Collection { get; set; }
        public bool CloseAllDay { get; set; }
        public int BusinessDetailId { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
    }
}
