using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class BussinessWebsiteDetail
    {
        public BussinessWebsiteDetail()
        {
            Testimonials = new HashSet<Testimonial>();
        }

        public int Id { get; set; }
        public string HeadMainContent { get; set; }
        public string HeadDescription { get; set; }
        public string AboutBussinessHead { get; set; }
        public string AboutBussinessContent { get; set; }
        public string AboutBussinessImageUrl1 { get; set; }
        public string AboutBussinessImageUrl2 { get; set; }
        public string ReservationLogo { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkdinLink { get; set; }
        public string DaysOfWeek1 { get; set; }
        public string DaysOfWeek2 { get; set; }
        public string Time1FromTo { get; set; }
        public string Time2FromTo { get; set; }
        public string GoogleMapUrl { get; set; }
        public string PopularTitle { get; set; }
        public string MainMenuTitle { get; set; }
        public string ContactImageUrl { get; set; }
        public int? BusinessDetailsId { get; set; }
        public string PrivacyPersonnel { get; set; }
        public string PrivacyQuery { get; set; }
        public string TermDeliveryOrder { get; set; }
        public string TermRefund { get; set; }
        public string HeadDescription2 { get; set; }

        public virtual BusinessDetail BusinessDetails { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
