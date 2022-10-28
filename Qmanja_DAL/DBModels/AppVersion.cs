using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class AppVersion
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public string Version { get; set; }
        public string Ip { get; set; }
    }
}
