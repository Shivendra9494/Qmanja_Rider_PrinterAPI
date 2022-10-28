using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class Discount
    {
        public int Id { get; set; }
        public int? DiscountPercentage { get; set; }
        public decimal? MinimumAmount { get; set; }
        public decimal? MaximumAmount { get; set; }
        public string Available { get; set; }
        public int? OrderCount { get; set; }
        public int BusinessDetailId { get; set; }
        public bool? CollectionAvailable { get; set; }
        public bool? DeliveryAvailable { get; set; }
        public bool? SundayAvailable { get; set; }
        public bool? MondayAvailable { get; set; }
        public bool? TuesdayAvailable { get; set; }
        public bool? WednesdayAvailable { get; set; }
        public bool? ThursdayAvaailable { get; set; }
        public bool? FridayAvailable { get; set; }
        public bool? SaturdayAvailable { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
    }
}
