using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rider_Printer_API.ViewModel
{
    public class POrderAcceptViewModel
    {
        public int ID { get; set; }
        public string DeliveryTime { get; set; }
        public string ResponceFromPrinter { get; set; }
    }
    public class POrderCancelViewModel
    {
        public int ID { get; set; }
        public DateTime CancelTime { get; set; }
        public string CancelledBy { get; set; }
    }
}
