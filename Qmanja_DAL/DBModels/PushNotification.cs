using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class PushNotification
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? NotificationDate { get; set; }
        public DateTime? NotificationTime { get; set; }
        public int BusinessDetailId { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
    }
}
