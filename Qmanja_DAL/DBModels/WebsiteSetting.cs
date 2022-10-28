using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class WebsiteSetting
    {
        public int Id { get; set; }
        public string Domain { get; set; }
        public bool UpdateSite { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public int BusinessDetailId { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
    }
}
