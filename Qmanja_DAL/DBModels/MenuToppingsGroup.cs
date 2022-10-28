using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class MenuToppingsGroup
    {
        public MenuToppingsGroup()
        {
            MenuToppings = new HashSet<MenuTopping>();
        }

        public int Id { get; set; }
        public string ToppingsGroup { get; set; }
        public string ToppingsGoupDisplayName { get; set; }
        public int BusinessDetailId { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
        public virtual ICollection<MenuTopping> MenuToppings { get; set; }
    }
}
