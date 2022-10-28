using Qmanja_BAL.Printer_BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rider_Printer_API.ViewModel
{
    public class DisableItemsViewModel
    {
        public string ItemType { get; set; }
        public DisabledItemLife Duration { get; set; }
        public int ItemId { get; set; }

    }
}
