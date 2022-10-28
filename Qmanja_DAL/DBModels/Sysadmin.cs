using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class Sysadmin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Userrolelabel { get; set; }
        public string Userrole { get; set; }
        public int? IdBusinessDetail { get; set; }
        public string Resetcode { get; set; }

        public virtual BusinessDetail IdBusinessDetailNavigation { get; set; }
    }
}
