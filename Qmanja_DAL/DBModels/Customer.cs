using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerCcs = new HashSet<CustomerCc>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pswd { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public int BusinessDetailId { get; set; }
        public string TermsAccepted { get; set; }
        public string TermsAcceptedAt { get; set; }
        public string TermsAcceptedIp { get; set; }
        public string Resetcode { get; set; }
        public string GoogleId { get; set; }
        public string FacebookId { get; set; }
        public string Token { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
        public virtual ICollection<CustomerCc> CustomerCcs { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
