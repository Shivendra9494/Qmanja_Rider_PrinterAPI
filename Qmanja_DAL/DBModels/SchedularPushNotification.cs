using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class SchedularPushNotification
    {
        public int Id { get; set; }
        public int BussinessDetailsId { get; set; }
        public DateTime ValidFromDate { get; set; }
        public DateTime ValidToDate { get; set; }
        public int Interval { get; set; }
        public int? PreferredTime { get; set; }
        public bool IsActive { get; set; }
        public string Content { get; set; }
        public DateTime StartFrom { get; set; }
        public DateTime? LastSentOn { get; set; }
    }
}
