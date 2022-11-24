using Qmanja_DAL.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Qmanja_BAL.Printer_BAL
{
    public interface IBLLPrinterOrders
    {

        Task<List<Order>> GetOrdersAsync(int businessid);
        Task<List<Order>> GetInKitchenOrdersAsync();
        Task<List<Order>> GetTodayOrderslistAsync();
        Task<List<Order>> GetOutForDeliveryOrdersAsync();
        Task<HttpStatusCode> AcceptOrderAsync(int id, string deliveryTime, string responceFromPrinter);
        Task<HttpStatusCode> CancelOrderAsync(int id, DateTime cancelTime, string CancelledBy);
        Task<HttpStatusCode> RiderLoctionAddAsync(int orderid, decimal RiderLat, decimal Riderlong);

        Task<Order> GetById(int orderId);
        Task<HttpStatusCode> OrderStatusById(int orderId, bool outofdelivery, string Status);

        Task<Order> CheckForNewOrder(int businessid);



    }
}
