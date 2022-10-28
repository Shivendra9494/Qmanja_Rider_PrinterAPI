using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class Charge
    {
        public int Id { get; set; }
        public bool IsFlat { get; set; }
        public bool IsPercentage { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DateTime? LastChargedOn { get; set; }
        public DateTime? NextDueOn { get; set; }
        public bool CashOrder { get; set; }
        public bool CardOrder { get; set; }
        public bool Codorder { get; set; }
        public bool DeliveryOrder { get; set; }
        public int Frequency { get; set; }
        public int BusinessDetailId { get; set; }
        public string Description { get; set; }
        public string FrequencyType { get; set; }
        public double? Factor { get; set; }
        public string BasedOn { get; set; }
        public string ChargeType { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
    }
}
