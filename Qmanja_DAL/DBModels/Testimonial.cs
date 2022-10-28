using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class Testimonial
    {
        public int Id { get; set; }
        public string TestimonailHead { get; set; }
        public string TestimonailImageUrl { get; set; }
        public string CustomerSuggestions { get; set; }
        public string CustomerName { get; set; }
        public string CustomerDesignation { get; set; }
        public int BussinessWebsiteDetailsId { get; set; }
        public string Suggestion2 { get; set; }
        public string Customer2Name { get; set; }
        public string Customer2Designation { get; set; }
        public string Suggestion3 { get; set; }
        public string Customer3Name { get; set; }
        public string Customer3Designation { get; set; }

        public virtual BussinessWebsiteDetail BussinessWebsiteDetails { get; set; }
    }
}
