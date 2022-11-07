using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class QFoodsContext : DbContext
    {
        public QFoodsContext()
        {
        }

        public QFoodsContext(DbContextOptions<QFoodsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountSheet> AccountSheets { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<AppRedirectInfo> AppRedirectInfos { get; set; }
        public virtual DbSet<AppVersion> AppVersions { get; set; }
        public virtual DbSet<AspNetSqlCacheTablesForChangeNotification> AspNetSqlCacheTablesForChangeNotifications { get; set; }
        public virtual DbSet<BlockedCustomer> BlockedCustomers { get; set; }
        public virtual DbSet<BusinessActiveStatus> BusinessActiveStatuses { get; set; }
        public virtual DbSet<BusinessDetail> BusinessDetails { get; set; }
        public virtual DbSet<BussinessWebsiteDetail> BussinessWebsiteDetails { get; set; }
        public virtual DbSet<Charge> Charges { get; set; }
        public virtual DbSet<Cmsuser> Cmsusers { get; set; }
        public virtual DbSet<CompanyInfo> CompanyInfos { get; set; }
        public virtual DbSet<CompanyInfoNote> CompanyInfoNotes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerCc> CustomerCcs { get; set; }
        public virtual DbSet<DeliveryAreaInfo> DeliveryAreaInfoes { get; set; }
        public virtual DbSet<DisabledItem> DisabledItems { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<DomainSuccessRecord> DomainSuccessRecords { get; set; }
        public virtual DbSet<EprintBusiness> EprintBusinesses { get; set; }
        public virtual DbSet<ExtraCharge> ExtraCharges { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceGroup> InvoiceGroups { get; set; }
        public virtual DbSet<InvoiceOrder> InvoiceOrders { get; set; }
        public virtual DbSet<MenuCategory> MenuCategories { get; set; }
        public virtual DbSet<MenuDishPropertiesGroup> MenuDishPropertiesGroups { get; set; }
        public virtual DbSet<MenuDishProperty> MenuDishProperties { get; set; }
        public virtual DbSet<MenuEditRole> MenuEditRoles { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<MenuItemModel> MenuItemModels { get; set; }
        public virtual DbSet<MenuItemProperty> MenuItemProperties { get; set; }
        public virtual DbSet<MenuItemPropertyModel> MenuItemPropertyModels { get; set; }
        public virtual DbSet<MenuTopping> MenuToppings { get; set; }
        public virtual DbSet<MenuToppingsGroup> MenuToppingsGroups { get; set; }
        public virtual DbSet<MenuUpdateRecord> MenuUpdateRecords { get; set; }
        public virtual DbSet<OpenOnCristma> OpenOnCristmas { get; set; }
        public virtual DbSet<OpenStatus> OpenStatuses { get; set; }
        public virtual DbSet<OpeningTime> OpeningTimes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderBoost> OrderBoosts { get; set; }
        public virtual DbSet<OrderBoostNote> OrderBoostNotes { get; set; }
        public virtual DbSet<OrderBoostPayment> OrderBoostPayments { get; set; }
        public virtual DbSet<OrderBoostPaymentTerm> OrderBoostPaymentTerms { get; set; }
        public virtual DbSet<OrderExtraCharge> OrderExtraCharges { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<OrderModel> OrderModels { get; set; }
        public virtual DbSet<OrderModelExtra> OrderModelExtras { get; set; }
        public virtual DbSet<OrderNote> OrderNotes { get; set; }
        public virtual DbSet<PushNotification> PushNotifications { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<RatingCategory> RatingCategories { get; set; }
        public virtual DbSet<RatingQuestion> RatingQuestions { get; set; }
        public virtual DbSet<SchedularPushNotification> SchedularPushNotifications { get; set; }
        public virtual DbSet<ShiftCollection> ShiftCollections { get; set; }
        public virtual DbSet<ShiftDelivery> ShiftDeliveries { get; set; }
        public virtual DbSet<Statement> Statements { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<SurveyCategory> SurveyCategories { get; set; }
        public virtual DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public virtual DbSet<Sysadmin> Sysadmins { get; set; }
        public virtual DbSet<Testimonial> Testimonials { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<VoucherCode> VoucherCodes { get; set; }
        public virtual DbSet<WebsiteSetting> WebsiteSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=test.c5x5w8cq92i6.eu-west-2.rds.amazonaws.com;Initial Catalog=QFoods;Persist Security Info=True;User ID=dbadminODProd;Password=sunil123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccountSheet>(entity =>
            {
                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailAccountSheet");

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetail_ID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsFreezed)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.On).HasColumnType("datetime");

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.AccountSheets)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessDetailAccountSheet");
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.At).HasColumnType("datetime");

                entity.Property(e => e.Controller).HasMaxLength(50);

                entity.Property(e => e.FullUrl).HasColumnName("FullURL");

                entity.Property(e => e.Ip)
                    .HasMaxLength(50)
                    .HasColumnName("IP");

                entity.Property(e => e.OrderStatus).HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserEmail).HasMaxLength(50);
            });

            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailAnnouncement");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessDetailAnnouncement");
            });

            modelBuilder.Entity<AppRedirectInfo>(entity =>
            {
                entity.ToTable("AppRedirectInfo");

                entity.Property(e => e.AccessedOn).HasColumnType("datetime");

                entity.Property(e => e.BrowserId).HasMaxLength(500);

                entity.Property(e => e.Ipaddress)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("IPAddress");
            });

            modelBuilder.Entity<AppVersion>(entity =>
            {
                entity.Property(e => e.Ip)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.Version)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AspNetSqlCacheTablesForChangeNotification>(entity =>
            {
                entity.HasKey(e => e.TableName)
                    .HasName("PK__AspNet_S__93F7AC69D1C69951");

                entity.ToTable("AspNet_SqlCacheTablesForChangeNotification");

                entity.Property(e => e.TableName).HasColumnName("tableName");

                entity.Property(e => e.ChangeId).HasColumnName("changeId");

                entity.Property(e => e.NotificationCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("notificationCreated")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<BlockedCustomer>(entity =>
            {
                entity.ToTable("BlockedCustomer");

                entity.Property(e => e.Email).HasMaxLength(500);

                entity.Property(e => e.Phone).HasMaxLength(500);
            });

            modelBuilder.Entity<BusinessActiveStatus>(entity =>
            {
                entity.ToTable("BusinessActiveStatus");

                entity.Property(e => e.DateFrom).HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.BusinessActiveStatuses)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessActiveStatus_BusinessDetails");
            });

            modelBuilder.Entity<BusinessDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Address1).HasMaxLength(500);

                entity.Property(e => e.Address2).HasMaxLength(500);

                entity.Property(e => e.Address3).HasMaxLength(500);

                entity.Property(e => e.AndoidAppLink).HasMaxLength(500);

                entity.Property(e => e.AndroidAppId).HasMaxLength(255);

                entity.Property(e => e.AppOrderingAllowed).HasDefaultValueSql("((1))");

                entity.Property(e => e.AppScreenshot).HasMaxLength(500);

                entity.Property(e => e.AppleUrl)
                    .HasMaxLength(500)
                    .HasColumnName("AppleURL");

                entity.Property(e => e.BusinessAddress1).HasMaxLength(500);

                entity.Property(e => e.BusinessAddress2).HasMaxLength(500);

                entity.Property(e => e.BusinessAddress3).HasMaxLength(500);

                entity.Property(e => e.BusinessName).HasMaxLength(500);

                entity.Property(e => e.BusinessPostcode).HasMaxLength(500);

                entity.Property(e => e.CardEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.CashEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.ClientId)
                    .HasMaxLength(255)
                    .HasColumnName("ClientID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Creditcardsurcharge)
                    .HasMaxLength(255)
                    .HasColumnName("CREDITCARDSURCHARGE");

                entity.Property(e => e.CssColor).HasMaxLength(500);

                entity.Property(e => e.Currencysymbol)
                    .HasMaxLength(255)
                    .HasColumnName("CURRENCYSYMBOL");

                entity.Property(e => e.DeliveryFee).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.DisableCollection)
                    .HasMaxLength(255)
                    .HasColumnName("Disable_Collection");

                entity.Property(e => e.DisableDelivery)
                    .HasMaxLength(255)
                    .HasColumnName("Disable_Delivery");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FixedCharges).HasDefaultValueSql("((0.30))");

                entity.Property(e => e.FoodType).HasMaxLength(255);

                entity.Property(e => e.GplaceId).HasColumnName("GPlaceId");

                entity.Property(e => e.IOsappId)
                    .HasMaxLength(255)
                    .HasColumnName("iOSAppID");

                entity.Property(e => e.ImgUrl).HasMaxLength(255);

                entity.Property(e => e.InvoiceStartFrom).HasColumnType("datetime");

                entity.Property(e => e.MinimumLoyalityAmount).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.NativeAppImage).HasMaxLength(500);

                entity.Property(e => e.NativeAppLogoUrl).HasMaxLength(500);

                entity.Property(e => e.PercentageCarges).HasDefaultValueSql("((2.9))");

                entity.Property(e => e.PostalCode).HasMaxLength(255);

                entity.Property(e => e.PrinterLastConnected).HasColumnType("datetime");

                entity.Property(e => e.Pswd)
                    .HasMaxLength(255)
                    .HasColumnName("pswd");

                entity.Property(e => e.SendOrdersToPrinter)
                    .HasMaxLength(255)
                    .HasColumnName("SEND_ORDERS_TO_PRINTER");

                entity.Property(e => e.ServiceCharge).HasMaxLength(255);

                entity.Property(e => e.TableOrderingAllowed).HasDefaultValueSql("((0))");

                entity.Property(e => e.Telephone).HasMaxLength(255);

                entity.Property(e => e.TransactionPercentage).HasMaxLength(255);

                entity.Property(e => e.WebSiteBackImageUrl).HasMaxLength(500);
            });

            modelBuilder.Entity<BussinessWebsiteDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BusinessDetailsId).HasColumnName("BusinessDetailsID");

                entity.Property(e => e.Time1FromTo).HasColumnName("Time1From_To");

                entity.Property(e => e.Time2FromTo).HasColumnName("Time2From_To");

                entity.HasOne(d => d.BusinessDetails)
                    .WithMany(p => p.BussinessWebsiteDetails)
                    .HasForeignKey(d => d.BusinessDetailsId)
                    .HasConstraintName("FK_dbo.BussinessWebsiteDetails_dbo.BusinessDetails_BusinessDetailsId");
            });

            modelBuilder.Entity<Charge>(entity =>
            {
                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailCharge");

                entity.Property(e => e.BasedOn).HasMaxLength(50);

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.ChargeType).HasMaxLength(50);

                entity.Property(e => e.Codorder).HasColumnName("CODOrder");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.FrequencyType).IsRequired();

                entity.Property(e => e.From).HasColumnType("datetime");

                entity.Property(e => e.LastChargedOn).HasColumnType("datetime");

                entity.Property(e => e.NextDueOn).HasColumnType("datetime");

                entity.Property(e => e.To).HasColumnType("datetime");

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.Charges)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessDetailCharge");
            });

            modelBuilder.Entity<Cmsuser>(entity =>
            {
                entity.ToTable("CMSUsers");

                entity.Property(e => e.Cmsrole).HasColumnName("CMSRole");

                entity.Property(e => e.CmsuserManagerRole).HasColumnName("CMSUserManagerRole");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("createdOn");

                entity.Property(e => e.Crmedit).HasColumnName("CRMEdit");

                entity.Property(e => e.Crmview).HasColumnName("CRMView");

                entity.Property(e => e.DefaultRole)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Password).HasMaxLength(500);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<CompanyInfo>(entity =>
            {
                entity.Property(e => e.ActivationDate).HasColumnName("Activation_Date");

                entity.Property(e => e.AddressStreet).HasColumnName("Address_Street");

                entity.Property(e => e.BillingAddressStreet).HasColumnName("Billing_Address_Street");

                entity.Property(e => e.BillingCity).HasColumnName("Billing_City");

                entity.Property(e => e.BillingCountry).HasColumnName("Billing_Country");

                entity.Property(e => e.BillingPostcode).HasColumnName("Billing_Postcode");

                entity.Property(e => e.BillingState).HasColumnName("Billing_State");

                entity.Property(e => e.BusinessType).HasColumnName("Business_Type");

                entity.Property(e => e.ClientRef).HasColumnName("Client_Ref");

                entity.Property(e => e.ContactName).HasColumnName("Contact_Name");

                entity.Property(e => e.ControlPanelPassword).HasColumnName("Control_panel_password");

                entity.Property(e => e.ControlPanelUsername).HasColumnName("Control_panel_username");

                entity.Property(e => e.DirectPhone).HasColumnName("Direct_Phone");

                entity.Property(e => e.DropboxLink).HasColumnName("Dropbox_Link");

                entity.Property(e => e.EmailAddress).HasColumnName("Email_Address");

                entity.Property(e => e.FaxPhone).HasColumnName("Fax_Phone");

                entity.Property(e => e.FirstName).HasColumnName("First_Name");

                entity.Property(e => e.HomeAddressStreet).HasColumnName("Home_Address_Street");

                entity.Property(e => e.HomeCity).HasColumnName("Home_City");

                entity.Property(e => e.HomeCountry).HasColumnName("Home_Country");

                entity.Property(e => e.HomeEmail).HasColumnName("Home_Email");

                entity.Property(e => e.HomePhone).HasColumnName("Home_Phone");

                entity.Property(e => e.HomePostcode).HasColumnName("Home_Postcode");

                entity.Property(e => e.HomeState).HasColumnName("Home_State");

                entity.Property(e => e.HomeWebsite).HasColumnName("Home_Website");

                entity.Property(e => e.JobTitle).HasColumnName("Job_Title");

                entity.Property(e => e.JustEatUrl).HasColumnName("Just_Eat_URL");

                entity.Property(e => e.LastContacted).HasColumnName("Last_Contacted");

                entity.Property(e => e.LastName).HasColumnName("Last_Name");

                entity.Property(e => e.MenuId).HasColumnName("Menu_ID");

                entity.Property(e => e.MobilePhone).HasColumnName("Mobile_Phone");

                entity.Property(e => e.OfficeAddressStreet).HasColumnName("Office_Address_Street");

                entity.Property(e => e.OfficeCity).HasColumnName("Office_City");

                entity.Property(e => e.OfficeCountry).HasColumnName("Office_Country");

                entity.Property(e => e.OfficePostcode).HasColumnName("Office_Postcode");

                entity.Property(e => e.OfficeState).HasColumnName("Office_State");

                entity.Property(e => e.PhoneNumber).HasColumnName("Phone_Number");

                entity.Property(e => e.PostalAddressStreet).HasColumnName("Postal_Address_Street");

                entity.Property(e => e.PostalCity).HasColumnName("Postal_City");

                entity.Property(e => e.PostalCountry).HasColumnName("Postal_Country");

                entity.Property(e => e.PostalPostcode).HasColumnName("Postal_Postcode");

                entity.Property(e => e.PostalState).HasColumnName("Postal_State");

                entity.Property(e => e.PrinterImei).HasColumnName("Printer_Imei");

                entity.Property(e => e.PrinterSerialNo).HasColumnName("Printer_Serial_No_");

                entity.Property(e => e.PrinterUpdate).HasColumnName("Printer_Update_");

                entity.Property(e => e.ReferalNo).HasColumnName("Referal_No_");

                entity.Property(e => e.SecondContactEmail).HasColumnName("Second_Contact_Email");

                entity.Property(e => e.SecondContactName).HasColumnName("Second_Contact_Name");

                entity.Property(e => e.SecondContactNumber).HasColumnName("Second_Contact_Number");

                entity.Property(e => e.ShippingAddressStreet).HasColumnName("Shipping_Address_Street");

                entity.Property(e => e.ShippingCity).HasColumnName("Shipping_City");

                entity.Property(e => e.ShippingCountry).HasColumnName("Shipping_Country");

                entity.Property(e => e.ShippingPostcode).HasColumnName("Shipping_Postcode");

                entity.Property(e => e.ShippingState).HasColumnName("Shipping_State");

                entity.Property(e => e.SignUpAgent).HasColumnName("Sign_Up_Agent");

                entity.Property(e => e.SimCardNumber).HasColumnName("Sim_Card_Number");

                entity.Property(e => e.StripeSetUp).HasColumnName("Stripe_set_up_");

                entity.Property(e => e.StripeSetUpDate).HasColumnName("Stripe_set_up_date");

                entity.Property(e => e.TakeawayUrl).HasColumnName("Takeaway_URL");

                entity.Property(e => e.WorkEmail).HasColumnName("Work_Email");

                entity.Property(e => e.WorkPhone).HasColumnName("Work_Phone");

                entity.Property(e => e.WorkWebsite).HasColumnName("Work_Website");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.CompanyInfos)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyInfos_BusinessDetails");
            });

            modelBuilder.Entity<CompanyInfoNote>(entity =>
            {
                entity.Property(e => e.TimeStamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.CompanyInfoNotes)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyInfoNotes_BusinessDetails");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CompanyInfoNotes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyInfoNotes_CMSUsers");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailCustomer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.FacebookId).HasMaxLength(500);

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.GoogleId).HasMaxLength(500);

                entity.Property(e => e.Resetcode)
                    .HasMaxLength(255)
                    .HasColumnName("resetcode");

                entity.Property(e => e.TermsAccepted).HasMaxLength(50);

                entity.Property(e => e.TermsAcceptedAt).HasMaxLength(255);

                entity.Property(e => e.TermsAcceptedIp)
                    .HasMaxLength(255)
                    .HasColumnName("TermsAcceptedIP");

                entity.Property(e => e.Token).HasMaxLength(500);

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessDetailCustomer");
            });

            modelBuilder.Entity<CustomerCc>(entity =>
            {
                entity.ToTable("CustomerCCs");

                entity.HasIndex(e => e.CustomerId, "IX_FK_CustomerCustomerCC");

                entity.Property(e => e.CardType).HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Expiry).HasMaxLength(50);

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.LastDigits)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerCcs)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerCustomerCC");
            });

            modelBuilder.Entity<DeliveryAreaInfo>(entity =>
            {
                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailDeliveryAreaInfo");

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.CreatedBy).HasMaxLength(255);

                entity.Property(e => e.CreatedByIp)
                    .HasMaxLength(255)
                    .HasColumnName("CreatedByIP");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveryFee).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.FreeOrder).HasMaxLength(255);

                entity.Property(e => e.MinimumOrder).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.ModifiedBy).HasMaxLength(255);

                entity.Property(e => e.ModifiedByIp)
                    .HasMaxLength(255)
                    .HasColumnName("ModifiedByIP");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PPostfix)
                    .HasMaxLength(255)
                    .HasColumnName("P_Postfix");

                entity.Property(e => e.PPrefix)
                    .HasMaxLength(255)
                    .HasColumnName("P_Prefix");

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.DeliveryAreaInfos)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryAreaInfoes_BusinessDetails");
            });

            modelBuilder.Entity<DisabledItem>(entity =>
            {
                entity.Property(e => e.From).HasColumnType("datetime");

                entity.Property(e => e.ItemType).IsRequired();

                entity.Property(e => e.To).HasColumnType("datetime");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailDiscount");

                entity.HasIndex(e => new { e.BusinessDetailId, e.Id }, "_dta_index_Discounts_7_1307151702__K7_K1_2_3_4_5_6");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Available).HasMaxLength(255);

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.CollectionAvailable).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeliveryAvailable).HasDefaultValueSql("((1))");

                entity.Property(e => e.FridayAvailable).HasDefaultValueSql("((1))");

                entity.Property(e => e.MaximumAmount).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.MinimumAmount).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.MondayAvailable).HasDefaultValueSql("((1))");

                entity.Property(e => e.SaturdayAvailable).HasDefaultValueSql("((1))");

                entity.Property(e => e.SundayAvailable).HasDefaultValueSql("((1))");

                entity.Property(e => e.ThursdayAvaailable).HasDefaultValueSql("((1))");

                entity.Property(e => e.TuesdayAvailable).HasDefaultValueSql("((1))");

                entity.Property(e => e.WednesdayAvailable).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.Discounts)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessDetailDiscount");
            });

            modelBuilder.Entity<DomainSuccessRecord>(entity =>
            {
                entity.ToTable("DomainSuccessRecord");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Currency)
                    .HasMaxLength(50)
                    .HasColumnName("currency");

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("domain");

                entity.Property(e => e.ItemCount).HasColumnName("itemCount");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.DomainSuccessRecords)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DomainSuccessRecord_BusinessDetails");
            });

            modelBuilder.Entity<EprintBusiness>(entity =>
            {
                entity.ToTable("EPrintBusiness");

                entity.Property(e => e.EndOn).HasColumnType("date");

                entity.Property(e => e.StartFrom).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(500);
            });

            modelBuilder.Entity<ExtraCharge>(entity =>
            {
                entity.ToTable("ExtraCharge");

                entity.Property(e => e.AddOnDiscount)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ChargeName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailInvoice");

                entity.HasIndex(e => e.InvoiceGroupId, "IX_FK_InvoiceGroupInvoice");

                entity.Property(e => e.AmountPaymentDate).IsRequired();

                entity.Property(e => e.BalanceFromPreviousStatementDate).IsRequired();

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.InvoiceDate).IsRequired();

                entity.Property(e => e.InvoiceNo).IsRequired();

                entity.Property(e => e.OdophctransactionFixedFee).HasColumnName("ODOPHCTransactionFixedFee");

                entity.Property(e => e.OdophctransactionPercentageFee).HasColumnName("ODOPHCTransactionPercentageFee");

                entity.Property(e => e.Period)
                    .IsRequired()
                    .HasColumnName("PERIOD");

                entity.Property(e => e.PeriodTo)
                    .IsRequired()
                    .HasColumnName("PERIOD_TO");

                entity.Property(e => e.TotalInclVat).HasColumnName("TotalInclVAT");

                entity.Property(e => e.TotalOdophcfee).HasColumnName("TotalODOPHCFee");

                entity.Property(e => e.Vat).HasColumnName("VAT");

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessDetailInvoice");

                entity.HasOne(d => d.InvoiceGroup)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.InvoiceGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceGroupInvoice");
            });

            modelBuilder.Entity<InvoiceGroup>(entity =>
            {
                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.ShowDay).HasMaxLength(50);

                entity.Property(e => e.Status).IsRequired();

                entity.Property(e => e.ToDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InvoiceOrder>(entity =>
            {
                entity.Property(e => e.Card)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Cash)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Total)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceOrders)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceOrders_Invoices");
            });

            modelBuilder.Entity<MenuCategory>(entity =>
            {
                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailMenuCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.MenuCategories)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuCategories_BusinessDetails");
            });

            modelBuilder.Entity<MenuDishPropertiesGroup>(entity =>
            {
                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailMenuDishPropertiesGroup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.DishPropertyGroup).HasMaxLength(255);

                entity.Property(e => e.DishPropertyGroupDisplayName).HasMaxLength(255);

                entity.Property(e => e.DishPropertyPriceType).HasMaxLength(255);

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.MenuDishPropertiesGroups)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuDishPropertiesGroups_BusinessDetails");
            });

            modelBuilder.Entity<MenuDishProperty>(entity =>
            {
                entity.HasIndex(e => e.MenuDishPropertiesGroupId, "IX_FK_MenuDishPropertiesGroupMenuDishProperty");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DishProperty).HasMaxLength(255);

                entity.Property(e => e.MenuDishPropertiesGroupId).HasColumnName("MenuDishPropertiesGroupID");

                entity.HasOne(d => d.MenuDishPropertiesGroup)
                    .WithMany(p => p.MenuDishProperties)
                    .HasForeignKey(d => d.MenuDishPropertiesGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuDishPropertiesGroupMenuDishProperty");
            });

            modelBuilder.Entity<MenuEditRole>(entity =>
            {
                entity.HasIndex(e => e.CmsuserId, "IX_FK_CMSUserMenuEditRole");

                entity.Property(e => e.CmsuserId).HasColumnName("CMSUserId");

                entity.Property(e => e.ValidUpTo).HasColumnType("datetime");

                entity.HasOne(d => d.Cmsuser)
                    .WithMany(p => p.MenuEditRoles)
                    .HasForeignKey(d => d.CmsuserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CMSUserMenuEditRole");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasIndex(e => e.MenuCategoryId, "IX_FK_MenuCategoryMenuItem");

                entity.Property(e => e.AllowToppings).HasMaxLength(255);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.ContainEggs).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountOff)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DishPropertyGroupId).HasMaxLength(255);

                entity.Property(e => e.IsChefSpecial).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsMustTry).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsRecommended).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsSeasonal).HasDefaultValueSql("((0))");

                entity.Property(e => e.MenuCategoryId).HasColumnName("MenuCategoryID");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.OriginalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Photo).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.MenuCategory)
                    .WithMany(p => p.MenuItems)
                    .HasForeignKey(d => d.MenuCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuCategoryMenuItem");
            });

            modelBuilder.Entity<MenuItemModel>(entity =>
            {
                entity.HasIndex(e => e.MenuItemId, "IX_FK_MenuItemMenuItemModels");

                entity.Property(e => e.ItemType).IsRequired();

                entity.Property(e => e.Label).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.HasOne(d => d.MenuItem)
                    .WithMany(p => p.MenuItemModels)
                    .HasForeignKey(d => d.MenuItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuItemMenuItemModels");
            });

            modelBuilder.Entity<MenuItemProperty>(entity =>
            {
                entity.HasIndex(e => e.IdMenuItem, "IX_FK_MenuItemProperties_MenuItems");

                entity.Property(e => e.AllowToppings).HasMaxLength(255);

                entity.Property(e => e.DiscountOffer).HasMaxLength(500);

                entity.Property(e => e.DishPropertiesGroupId).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.OriginalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdMenuItemNavigation)
                    .WithMany(p => p.MenuItemProperties)
                    .HasForeignKey(d => d.IdMenuItem)
                    .HasConstraintName("FK_MenuItemProperties_MenuItems");
            });

            modelBuilder.Entity<MenuItemPropertyModel>(entity =>
            {
                entity.HasIndex(e => e.MenuItemPropertyId, "IX_FK_MenuItemPropertyMenuItemPropertyModels");

                entity.Property(e => e.ItemType).IsRequired();

                entity.Property(e => e.Label).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.HasOne(d => d.MenuItemProperty)
                    .WithMany(p => p.MenuItemPropertyModels)
                    .HasForeignKey(d => d.MenuItemPropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuItemPropertyMenuItemPropertyModels");
            });

            modelBuilder.Entity<MenuTopping>(entity =>
            {
                entity.HasIndex(e => e.MenuToppingsGroupId, "IX_FK_MenuToppingsGroupMenuTopping");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MenuToppingsGroupId).HasColumnName("MenuToppingsGroupID");

                entity.Property(e => e.Topping).HasMaxLength(255);

                entity.HasOne(d => d.MenuToppingsGroup)
                    .WithMany(p => p.MenuToppings)
                    .HasForeignKey(d => d.MenuToppingsGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuToppingsGroupMenuTopping");
            });

            modelBuilder.Entity<MenuToppingsGroup>(entity =>
            {
                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailMenuToppingsGroup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.ToppingsGoupDisplayName).HasMaxLength(255);

                entity.Property(e => e.ToppingsGroup).HasMaxLength(255);

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.MenuToppingsGroups)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuToppingsGroups_BusinessDetails");
            });

            modelBuilder.Entity<MenuUpdateRecord>(entity =>
            {
                entity.ToTable("MenuUpdateRecord");

                entity.Property(e => e.MenuUpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.MenuUpdateRecords)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuUpdateRecord_BusinessDetails");
            });

            modelBuilder.Entity<OpenStatus>(entity =>
            {
                entity.ToTable("OpenStatus");

                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailOpenStatu");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.DateOn).HasColumnType("datetime");

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.OpenStatuses)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpenStatus_BusinessDetails");
            });

            modelBuilder.Entity<OpeningTime>(entity =>
            {
                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailOpeningTime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.Collection).HasMaxLength(255);

                entity.Property(e => e.Delivery).HasMaxLength(255);

                entity.Property(e => e.HourFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("Hour_From");

                entity.Property(e => e.HourTo)
                    .HasColumnType("datetime")
                    .HasColumnName("Hour_To");

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.OpeningTimes)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpeningTimes_BusinessDetails");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => new { e.BusinessDetailId, e.OrderDate, e.Printed }, "IX_orders_multi");

                entity.HasIndex(e => new { e.Acknowledged, e.OrderDate, e.Printed, e.Status }, "_dta_index_Orders_7_1163151189__K25_K3_K29_K36_1_2_4_5_6_7_8_9_10_11_12_13_14_15_16_17_18_19_20_21_22_23_24_26_27_28_30_31_32_");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcknowledgedDate).HasColumnType("datetime");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.AllResolved).HasDefaultValueSql("((0))");

                entity.Property(e => e.AllResolvedAt).HasColumnType("datetime");

                entity.Property(e => e.AppType).HasMaxLength(100);

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.CancelledBy).HasMaxLength(255);

                entity.Property(e => e.CancelledDate).HasColumnType("datetime");

                entity.Property(e => e.CancelledReason).HasMaxLength(255);

                entity.Property(e => e.CardFee).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.ClientIp)
                    .HasMaxLength(255)
                    .HasColumnName("ClientIP");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DeliveredDate).HasMaxLength(255);

                entity.Property(e => e.DeliveryTime).HasMaxLength(255);

                entity.Property(e => e.DeliveryType).HasMaxLength(255);

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

                entity.Property(e => e.DiscountPercentage).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderTotal).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.PaymentType).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.PostalCode).HasMaxLength(255);

                entity.Property(e => e.PrinterStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ResponceFromPrinter).HasMaxLength(255);

                entity.Property(e => e.RiderLatitude).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.RiderLongitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.SagePayAuth).HasMaxLength(255);

                entity.Property(e => e.ServiceCharge).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.SessionId).HasMaxLength(255);

                entity.Property(e => e.ShippingFee).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.SubTotal).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.SupportAcknowledged).HasDefaultValueSql("((0))");

                entity.Property(e => e.SupportAcknowledgedAt).HasColumnType("datetime");

                entity.Property(e => e.VoucherCode).HasMaxLength(255);

                entity.Property(e => e.VoucherCodeDiscount).HasColumnType("decimal(19, 2)");

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_BusinessDetails");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customers");
            });

            modelBuilder.Entity<OrderBoost>(entity =>
            {
                entity.Property(e => e.CompletedOn).HasColumnType("datetime");

                entity.Property(e => e.StartedOn).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(500);

                entity.Property(e => e.StatusOnComplete).HasMaxLength(500);

                entity.Property(e => e.StatusOnStart).HasMaxLength(500);

                entity.HasOne(d => d.Booster)
                    .WithMany(p => p.OrderBoosts)
                    .HasForeignKey(d => d.BoosterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderBoosts_CMSUsers");

                entity.HasOne(d => d.BusinessDeatil)
                    .WithMany(p => p.OrderBoosts)
                    .HasForeignKey(d => d.BusinessDeatilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderBoosts_BusinessDetails");
            });

            modelBuilder.Entity<OrderBoostNote>(entity =>
            {
                entity.Property(e => e.TimeStamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.OrderBoostNotes)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderBoostNotes_BusinessDetails");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderBoostNotes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderBoostNotes_CMSUsers");
            });

            modelBuilder.Entity<OrderBoostPayment>(entity =>
            {
                entity.ToTable("OrderBoostPayment");

                entity.Property(e => e.EndedOn).HasColumnType("datetime");

                entity.Property(e => e.PaidOn).HasColumnType("datetime");

                entity.Property(e => e.StartedFrom).HasColumnType("datetime");

                entity.HasOne(d => d.OrderBoost)
                    .WithMany(p => p.OrderBoostPayments)
                    .HasForeignKey(d => d.OrderBoostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderBoostPayment_OrderBoosts");
            });

            modelBuilder.Entity<OrderBoostPaymentTerm>(entity =>
            {
                entity.ToTable("OrderBoostPaymentTerm");
            });

            modelBuilder.Entity<OrderExtraCharge>(entity =>
            {
                entity.Property(e => e.AddOnDiscount)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ChargeName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasIndex(e => e.OrderId, "IX_orderitems_orderid");

                entity.HasIndex(e => new { e.OrderId, e.Id }, "_dta_index_OrderItems_7_1822629536__K7_K1_2_3_4_5_6_8_9_10_11");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DishPropertiesIds).HasMaxLength(255);

                entity.Property(e => e.ItemType).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ToppingIds).HasMaxLength(255);

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItems2_Orders21");
            });

            modelBuilder.Entity<OrderModel>(entity =>
            {
                entity.HasIndex(e => e.OrderItemId, "IX_FK_OrderItemOrderModel");

                entity.Property(e => e.ItemName).IsRequired();

                entity.Property(e => e.ItemType).IsRequired();

                entity.Property(e => e.OptionId).HasColumnName("OptionID");

                entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Qty).IsRequired();

                entity.HasOne(d => d.OrderItem)
                    .WithMany(p => p.OrderModels)
                    .HasForeignKey(d => d.OrderItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItemOrderModel");
            });

            modelBuilder.Entity<OrderModelExtra>(entity =>
            {
                entity.HasIndex(e => e.OrderModelId, "IX_FK_OrderModelOrderModelExtra");

                entity.Property(e => e.ItemName).IsRequired();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Qty).IsRequired();

                entity.HasOne(d => d.OrderModel)
                    .WithMany(p => p.OrderModelExtras)
                    .HasForeignKey(d => d.OrderModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderModelOrderModelExtra");
            });

            modelBuilder.Entity<OrderNote>(entity =>
            {
                entity.Property(e => e.TimeStamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderNotes)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderNotes_Orders");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderNotes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderNotes_CMSUsers");
            });

            modelBuilder.Entity<PushNotification>(entity =>
            {
                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailPushNotification");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.NotificationDate).HasColumnType("datetime");

                entity.Property(e => e.NotificationTime).HasColumnType("datetime");

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.PushNotifications)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PushNotifications_BusinessDetails");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(500);

                entity.Property(e => e.Mobile).HasMaxLength(500);

                entity.Property(e => e.UserName).HasMaxLength(500);

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_Survey");
            });

            modelBuilder.Entity<RatingCategory>(entity =>
            {
                entity.ToTable("RatingCategory");

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.RatingCategories)
                    .HasForeignKey(d => d.RatingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RatingCategory_Rating");

                entity.HasOne(d => d.SurveyCategory)
                    .WithMany(p => p.RatingCategories)
                    .HasForeignKey(d => d.SurveyCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RatingCategory_SurveyCategory");
            });

            modelBuilder.Entity<RatingQuestion>(entity =>
            {
                entity.ToTable("RatingQuestion");

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.RatingQuestions)
                    .HasForeignKey(d => d.RatingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RatingQuestion_Rating");

                entity.HasOne(d => d.SurveyQuestion)
                    .WithMany(p => p.RatingQuestions)
                    .HasForeignKey(d => d.SurveyQuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RatingQuestion_SurveyQuestion");
            });

            modelBuilder.Entity<SchedularPushNotification>(entity =>
            {
                entity.ToTable("SchedularPushNotification");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.LastSentOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ShiftCollection>(entity =>
            {
                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailShiftCollection");

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.ShiftType).IsRequired();

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.ShiftCollections)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessDetailShiftCollection");
            });

            modelBuilder.Entity<ShiftDelivery>(entity =>
            {
                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailShiftDelivery");

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.ShiftType).IsRequired();

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.ShiftDeliveries)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessDetailShiftDelivery");
            });

            modelBuilder.Entity<Statement>(entity =>
            {
                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailStatement");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.Invoices).HasMaxLength(255);

                entity.Property(e => e.StatementText).HasMaxLength(255);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.Statements)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Statements_BusinessDetails");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.ToTable("Survey");

                entity.Property(e => e.EndOn).HasColumnType("datetime");

                entity.Property(e => e.StartFrom).HasColumnType("datetime");
            });

            modelBuilder.Entity<SurveyCategory>(entity =>
            {
                entity.ToTable("SurveyCategory");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.SurveyCategories)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyCategory_Survey");
            });

            modelBuilder.Entity<SurveyQuestion>(entity =>
            {
                entity.ToTable("SurveyQuestion");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.SurveyQuestions)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyQuestion_Survey");
            });

            modelBuilder.Entity<Sysadmin>(entity =>
            {
                entity.ToTable("sysadmin");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Resetcode)
                    .HasMaxLength(255)
                    .HasColumnName("resetcode");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.Property(e => e.Userrole)
                    .HasMaxLength(50)
                    .HasColumnName("userrole");

                entity.Property(e => e.Userrolelabel)
                    .HasMaxLength(50)
                    .HasColumnName("userrolelabel");

                entity.HasOne(d => d.IdBusinessDetailNavigation)
                    .WithMany(p => p.Sysadmins)
                    .HasForeignKey(d => d.IdBusinessDetail)
                    .HasConstraintName("FK_sysadmin_BusinessDetails");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("Testimonial");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.BussinessWebsiteDetails)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.BussinessWebsiteDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Testimonial_dbo.BussinessWebsiteDetails_BussinessWebsiteDetailsId");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailTransaction");

                entity.HasIndex(e => e.InvoiceId, "IX_FK_InvoiceTransaction");

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.On).HasColumnType("datetime");

                entity.Property(e => e.Vat).HasColumnName("VAT");

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessDetailTransaction");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("FK_InvoiceTransaction");
            });

            modelBuilder.Entity<VoucherCode>(entity =>
            {
                entity.HasIndex(e => e.BusinessDetailId, "IX_FK_BusinessDetailVoucherCode");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BusinessDetailId).HasColumnName("BusinessDetailID");

                entity.Property(e => e.EndDate).HasMaxLength(255);

                entity.Property(e => e.StartDate).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.VoucherCodeText).HasMaxLength(255);

                entity.Property(e => e.VoucherType).HasMaxLength(255);

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.VoucherCodes)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoucherCodes_BusinessDetails");
            });

            modelBuilder.Entity<WebsiteSetting>(entity =>
            {
                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.BusinessDetail)
                    .WithMany(p => p.WebsiteSettings)
                    .HasForeignKey(d => d.BusinessDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WebsiteSettings_BusinessDetails");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
