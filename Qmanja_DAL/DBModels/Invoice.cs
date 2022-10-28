using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceOrders = new HashSet<InvoiceOrder>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Period { get; set; }
        public string PeriodTo { get; set; }
        public double ReceiveableAmount { get; set; }
        public string AmountPaymentDate { get; set; }
        public int NumberOfOrders { get; set; }
        public int OrdersForDelivery { get; set; }
        public int OrdersForCollection { get; set; }
        public double TotalSales { get; set; }
        public double OnlinePaymentOrdersTotalling { get; set; }
        public double CashOrdersTotalling { get; set; }
        public double OdophctransactionPercentageFee { get; set; }
        public double OdophctransactionFixedFee { get; set; }
        public double TotalOdophcfee { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public double WeeklySubscriptionFee { get; set; }
        public double AdministrationFeeAmount { get; set; }
        public double AdministrationFeeTotal { get; set; }
        public double Subtotal { get; set; }
        public double Vat { get; set; }
        public double TotalInclVat { get; set; }
        public string BalanceFromPreviousStatementDate { get; set; }
        public double BalanceFromPreviousStatementAmount { get; set; }
        public double AccountBalance { get; set; }
        public int BusinessDetailId { get; set; }
        public int InvoiceGroupId { get; set; }
        public int NumberOfCardOrders { get; set; }
        public int NumberOfCashOrders { get; set; }

        public virtual BusinessDetail BusinessDetail { get; set; }
        public virtual InvoiceGroup InvoiceGroup { get; set; }
        public virtual ICollection<InvoiceOrder> InvoiceOrders { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
