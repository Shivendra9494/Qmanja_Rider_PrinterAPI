using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class MenuItemModel
    {
        public int Id { get; set; }
        public int DisplayOrder { get; set; }
        public string ItemType { get; set; }
        public int ItemId { get; set; }
        public int MenuItemId { get; set; }
        public int? MinQty { get; set; }
        public int? MaxQty { get; set; }
        public int? MaxSelectionPerItem { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }

        public virtual MenuItem MenuItem { get; set; }
    }
}
