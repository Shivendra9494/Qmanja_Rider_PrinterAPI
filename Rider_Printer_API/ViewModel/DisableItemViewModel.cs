using Qmanja_BAL.Printer_BAL;
using System;

namespace Rider_Printer_API.ViewModel
{
    public class DisableItemViewModel
    {
        public int Id { get; set; }
        public DateTime DisabledUpto { get; set; }
        public int IsDisabled { get; set; }
    }
}
