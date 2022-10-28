using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class CustomerCc
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string LastDigits { get; set; }
        public int CustomerId { get; set; }
        public string CardType { get; set; }
        public string Expiry { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
