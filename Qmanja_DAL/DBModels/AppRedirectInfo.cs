using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class AppRedirectInfo
    {
        public int Id { get; set; }
        public string Ipaddress { get; set; }
        public int RestId { get; set; }
        public DateTime AccessedOn { get; set; }
        public string BrowserId { get; set; }
    }
}
