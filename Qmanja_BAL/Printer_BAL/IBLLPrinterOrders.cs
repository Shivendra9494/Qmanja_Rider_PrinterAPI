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

        Task<List<Order>> GetOrdersAsync();
        Task<List<Order>> GetInKitchenOrdersAsync();
        Task<List<Order>> GetOutForDeliveryOrdersAsync();
        Task<HttpStatusCode> AcceptOrderAsync(int id, string deliveryTime, string responceFromPrinter);

        Task<Order> GetById(int orderId);
        Task<Order> OrderStatusById(int orderId, string orderSatus);

        Task<Order> CheckForNewOrder();



    }
}
