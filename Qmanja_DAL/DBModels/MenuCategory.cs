using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class MenuCategory
    {
        public MenuCategory()
        {
            MenuItems = new HashSet<MenuItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? DisplayOrder { get; set; }
        public int BusinessDetailId { get; set; }
        public bool IsDeleted { get; set; }
        public string ImagePath { get; set; }
        public string TopCategoryName { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
