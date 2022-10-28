using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class MenuEditRole
    {
        public int Id { get; set; }
        public DateTime ValidUpTo { get; set; }
        public bool AllowAll { get; set; }
        public string MenuIds { get; set; }
        public int CmsuserId { get; set; }

        public virtual Cmsuser Cmsuser { get; set; }
    }
}
