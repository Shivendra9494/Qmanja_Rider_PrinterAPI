using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class Cmsuser
    {
        public Cmsuser()
        {
            CompanyInfoNotes = new HashSet<CompanyInfoNote>();
            MenuEditRoles = new HashSet<MenuEditRole>();
            OrderBoostNotes = new HashSet<OrderBoostNote>();
            OrderBoosts = new HashSet<OrderBoost>();
            OrderNotes = new HashSet<OrderNote>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Cmsrole { get; set; }
        public bool SagepayCheckerRole { get; set; }
        public bool SupportRole { get; set; }
        public bool MenuEditRole { get; set; }
        public bool AccountsRole { get; set; }
        public bool IsActive { get; set; }
        public string DefaultRole { get; set; }
        public bool PartnerCenterRole { get; set; }
        public bool AccountAuditorRole { get; set; }
        public bool BusinessCreatorRole { get; set; }
        public bool NativeAppSettingRole { get; set; }
        public bool SagePayManagerRole { get; set; }
        public bool CmsuserManagerRole { get; set; }
        public bool SalesRole { get; set; }
        public bool Crmview { get; set; }
        public bool Crmedit { get; set; }
        public bool OrderBooster { get; set; }
        public bool BoosterManager { get; set; }
        public bool BoosterAdmin { get; set; }

        public virtual ICollection<CompanyInfoNote> CompanyInfoNotes { get; set; }
        public virtual ICollection<MenuEditRole> MenuEditRoles { get; set; }
        public virtual ICollection<OrderBoostNote> OrderBoostNotes { get; set; }
        public virtual ICollection<OrderBoost> OrderBoosts { get; set; }
        public virtual ICollection<OrderNote> OrderNotes { get; set; }
    }
}
