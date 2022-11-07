using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
            OrderNotes = new HashSet<OrderNote>();
        }

        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? OrderDate { get; set; }
        public string DeliveryType { get; set; }
        public string DeliveryTime { get; set; }
        public string PaymentType { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? ShippingFee { get; set; }
        public decimal? OrderTotal { get; set; }
        public string SessionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Notes { get; set; }
        public string ResponceFromPrinter { get; set; }
        public DateTime? CancelledDate { get; set; }
        public string CancelledBy { get; set; }
        public string CancelledReason { get; set; }
        public DateTime? AcknowledgedDate { get; set; }
        public string DeliveredDate { get; set; }
        public bool Cancelled { get; set; }
        public bool Acknowledged { get; set; }
        public bool OutForDelivery { get; set; }
        public decimal? VoucherCodeDiscount { get; set; }
        public string VoucherCode { get; set; }
        public bool Printed { get; set; }
        public decimal? Discount { get; set; }
        public int? DiscountId { get; set; }
        public decimal? CardFee { get; set; }
        public decimal? ServiceCharge { get; set; }
        public int BusinessDetailId { get; set; }
        public int? CustomerId { get; set; }
        public string Status { get; set; }
        public string ClientIp { get; set; }
        public bool ValidForLoyality { get; set; }
        public string OrderText { get; set; }
        public string DiscountPercentage { get; set; }
        public string SagePayAuth { get; set; }
        public bool? SupportAcknowledged { get; set; }
        public bool? AllResolved { get; set; }
        public DateTime? SupportAcknowledgedAt { get; set; }
        public DateTime? AllResolvedAt { get; set; }
        public string AppType { get; set; }
        public int? SupportAgentId { get; set; }
        public string PrinterStatus { get; set; }
        public decimal? RiderLongitude { get; set; }
        public decimal? RiderLatitude { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<OrderNote> OrderNotes { get; set; }
    }
}
