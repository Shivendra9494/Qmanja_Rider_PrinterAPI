using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class BusinessDetail
    {
        public BusinessDetail()
        {
            AccountSheets = new HashSet<AccountSheet>();
            Announcements = new HashSet<Announcement>();
            BusinessActiveStatuses = new HashSet<BusinessActiveStatus>();
            BussinessWebsiteDetails = new HashSet<BussinessWebsiteDetail>();
            Charges = new HashSet<Charge>();
            CompanyInfoNotes = new HashSet<CompanyInfoNote>();
            CompanyInfos = new HashSet<CompanyInfo>();
            Customers = new HashSet<Customer>();
            DeliveryAreaInfos = new HashSet<DeliveryAreaInfo>();
            Discounts = new HashSet<Discount>();
            DomainSuccessRecords = new HashSet<DomainSuccessRecord>();
            Invoices = new HashSet<Invoice>();
            MenuCategories = new HashSet<MenuCategory>();
            MenuDishPropertiesGroups = new HashSet<MenuDishPropertiesGroup>();
            MenuToppingsGroups = new HashSet<MenuToppingsGroup>();
            MenuUpdateRecords = new HashSet<MenuUpdateRecord>();
            OpenStatuses = new HashSet<OpenStatus>();
            OpeningTimes = new HashSet<OpeningTime>();
            OrderBoostNotes = new HashSet<OrderBoostNote>();
            OrderBoosts = new HashSet<OrderBoost>();
            Orders = new HashSet<Order>();
            PushNotifications = new HashSet<PushNotification>();
            ShiftCollections = new HashSet<ShiftCollection>();
            ShiftDeliveries = new HashSet<ShiftDelivery>();
            Statements = new HashSet<Statement>();
            Sysadmins = new HashSet<Sysadmin>();
            Transactions = new HashSet<Transaction>();
            VoucherCodes = new HashSet<VoucherCode>();
            WebsiteSettings = new HashSet<WebsiteSetting>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string FoodType { get; set; }
        public int? DeliveryMinAmount { get; set; }
        public double? DeliveryMaxDistance { get; set; }
        public double? DeliveryFreeDistance { get; set; }
        public int? AverageDeliveryTime { get; set; }
        public int? AverageCollectionTime { get; set; }
        public decimal? DeliveryFee { get; set; }
        public string ImgUrl { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Pswd { get; set; }
        public bool BusinessClosed { get; set; }
        public string Announcement { get; set; }
        public string Currencysymbol { get; set; }
        public string Creditcardsurcharge { get; set; }
        public string SendOrdersToPrinter { get; set; }
        public int? IdTimeZone { get; set; }
        public string DisableDelivery { get; set; }
        public string DisableCollection { get; set; }
        public string ClientId { get; set; }
        public string TransactionPercentage { get; set; }
        public string ServiceCharge { get; set; }
        public bool? LoyaltyEnabled { get; set; }
        public decimal? MinimumLoyalityAmount { get; set; }
        public bool? CashEnabled { get; set; }
        public bool? CardEnabled { get; set; }
        public string IOsappId { get; set; }
        public string AndroidAppId { get; set; }
        public DateTime? InvoiceStartFrom { get; set; }
        public double WeeklyFee { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public string NativeAppImage { get; set; }
        public string AppleUrl { get; set; }
        public string BusinessName { get; set; }
        public string BusinessAddress1 { get; set; }
        public string BusinessAddress2 { get; set; }
        public string BusinessAddress3 { get; set; }
        public string BusinessPostcode { get; set; }
        public string NativeAppLogoUrl { get; set; }
        public string WebSiteBackImageUrl { get; set; }
        public bool? AppOrderingAllowed { get; set; }
        public bool? TableOrderingAllowed { get; set; }
        public int? PrinterId { get; set; }
        public string Domain { get; set; }
        public string AndoidAppLink { get; set; }
        public string AppScreenshot { get; set; }
        public string CssColor { get; set; }
        public DateTime? PrinterLastConnected { get; set; }
        public DateTime? CreatedOn { get; set; }
        public double PercentageCarges { get; set; }
        public double FixedCharges { get; set; }
        public string GplaceId { get; set; }

        public virtual ICollection<AccountSheet> AccountSheets { get; set; }
        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<BusinessActiveStatus> BusinessActiveStatuses { get; set; }
        public virtual ICollection<BussinessWebsiteDetail> BussinessWebsiteDetails { get; set; }
        public virtual ICollection<Charge> Charges { get; set; }
        public virtual ICollection<CompanyInfoNote> CompanyInfoNotes { get; set; }
        public virtual ICollection<CompanyInfo> CompanyInfos { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<DeliveryAreaInfo> DeliveryAreaInfos { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<DomainSuccessRecord> DomainSuccessRecords { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<MenuCategory> MenuCategories { get; set; }
        public virtual ICollection<MenuDishPropertiesGroup> MenuDishPropertiesGroups { get; set; }
        public virtual ICollection<MenuToppingsGroup> MenuToppingsGroups { get; set; }
        public virtual ICollection<MenuUpdateRecord> MenuUpdateRecords { get; set; }
        public virtual ICollection<OpenStatus> OpenStatuses { get; set; }
        public virtual ICollection<OpeningTime> OpeningTimes { get; set; }
        public virtual ICollection<OrderBoostNote> OrderBoostNotes { get; set; }
        public virtual ICollection<OrderBoost> OrderBoosts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<PushNotification> PushNotifications { get; set; }
        public virtual ICollection<ShiftCollection> ShiftCollections { get; set; }
        public virtual ICollection<ShiftDelivery> ShiftDeliveries { get; set; }
        public virtual ICollection<Statement> Statements { get; set; }
        public virtual ICollection<Sysadmin> Sysadmins { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<VoucherCode> VoucherCodes { get; set; }
        public virtual ICollection<WebsiteSetting> WebsiteSettings { get; set; }
    }
}
