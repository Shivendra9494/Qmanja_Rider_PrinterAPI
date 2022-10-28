using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class Activity
    {
        public int Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string UserEmail { get; set; }
        public int? OrderId { get; set; }
        public string OrderStatus { get; set; }
        public string Error { get; set; }
        public string Ip { get; set; }
        public int? RestoId { get; set; }
        public DateTime? At { get; set; }
        public string FullUrl { get; set; }
        public string Status { get; set; }
    }
}
