using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qmanja_BAL.ViewModels
{
    public  class ItemStatusViewModel
    {
        public int Id { get; set; }
        public DateTime DisabledUpto { get; set; }
        public bool IsDisabled { get; set; }
    }
}
