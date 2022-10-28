using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class CompanyInfo
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Organization { get; set; }
        public string Created { get; set; }
        public string Updated { get; set; }
        public string LastContacted { get; set; }
        public string EmailAddress { get; set; }
        public string HomeEmail { get; set; }
        public string WorkEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string FaxPhone { get; set; }
        public string DirectPhone { get; set; }
        public string AddressStreet { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string HomeAddressStreet { get; set; }
        public string HomeCity { get; set; }
        public string HomeState { get; set; }
        public string HomePostcode { get; set; }
        public string HomeCountry { get; set; }
        public string PostalAddressStreet { get; set; }
        public string PostalCity { get; set; }
        public string PostalState { get; set; }
        public string PostalPostcode { get; set; }
        public string PostalCountry { get; set; }
        public string OfficeAddressStreet { get; set; }
        public string OfficeCity { get; set; }
        public string OfficeState { get; set; }
        public string OfficePostcode { get; set; }
        public string OfficeCountry { get; set; }
        public string BillingAddressStreet { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingPostcode { get; set; }
        public string BillingCountry { get; set; }
        public string ShippingAddressStreet { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingPostcode { get; set; }
        public string ShippingCountry { get; set; }
        public string Stage { get; set; }
        public string SecondContactName { get; set; }
        public string SecondContactNumber { get; set; }
        public string SecondContactEmail { get; set; }
        public string ClientRef { get; set; }
        public int MenuId { get; set; }
        public string TakeawayUrl { get; set; }
        public string JustEatUrl { get; set; }
        public string ControlPanelUsername { get; set; }
        public string ControlPanelPassword { get; set; }
        public string SignUpAgent { get; set; }
        public string SimCardNumber { get; set; }
        public string PrinterSerialNo { get; set; }
        public string PrinterImei { get; set; }
        public string PrinterUpdate { get; set; }
        public string ActivationDate { get; set; }
        public string StripeSetUp { get; set; }
        public string StripeSetUpDate { get; set; }
        public string BusinessType { get; set; }
        public string ContactName { get; set; }
        public string DropboxLink { get; set; }
        public string ReferalNo { get; set; }
        public string Tags { get; set; }
        public string Website { get; set; }
        public string HomeWebsite { get; set; }
        public string WorkWebsite { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Skype { get; set; }
        public string LinkedIn { get; set; }
        public string YouTube { get; set; }
        public string Instagram { get; set; }
        public string About { get; set; }
        public string History { get; set; }
        public int Id { get; set; }

        public virtual BusinessDetail Menu { get; set; }
    }
}
