using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qmanja_BAL.Printer_BAL;
using Qmanja_DAL.DBModels;
using Rider_Printer_API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Rider_Printer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POrdersController : ControllerBase
    {

        private readonly IBLLPrinterOrders _printerOrders;
        //  BLLPrinterMenuItems _printerMenu = new BLLPrinterMenuItems();

        public POrdersController(IBLLPrinterOrders printerOrders)
        {
            _printerOrders = printerOrders;
        }
      
        [HttpGet("Active")]
        public async Task<List<Order>> GetOrders([System.Web.Http.FromUri] int businessid)
        {
            return await _printerOrders.GetOrdersAsync(businessid);
        }

    
        [HttpGet("InKitchen")]
        public async Task<List<Order>> GetInKitchenOrders()
        {
            return await _printerOrders.GetInKitchenOrdersAsync();
        }

        [HttpGet("GetTodayOrders")]
        public async Task<List<Order>> GetTodayOrderslist([System.Web.Http.FromUri] int businessid)
        {
            return await _printerOrders.GetTodayOrderslistAsync(businessid);
        }

        [HttpGet("OutForDelivery")]
        public async Task<List<Order>> GetOutForDeliveryOrders()
        {
            return await _printerOrders.GetOutForDeliveryOrdersAsync();
        }

      
        [HttpPut("AcceptOrder")]
        public async Task<HttpStatusCode> PutAcceptOrder([FromBody] POrderAcceptViewModel order)
        {
            if (order == null) return HttpStatusCode.BadRequest;
            return await _printerOrders.AcceptOrderAsync(order.ID, order.DeliveryTime, order.ResponceFromPrinter);

        }
        [HttpPut("CancelOrder")]
        public async Task<HttpStatusCode> PutCancelOrder([FromBody] POrderCancelViewModel order)
        {
            if (order == null) return HttpStatusCode.BadRequest;
            return await _printerOrders.CancelOrderAsync(order.ID, order.CancelTime, order.CancelledBy);

        }


        [HttpGet("Order")]
        public async Task<Order> GetOrderById([System.Web.Http.FromUri] int orderId)
        {
            if (orderId < 0) throw new Exception("Invalid Id");
            return await _printerOrders.GetById(orderId);
        }

        [HttpPut("UpdateOrderStatusAPI")]
        public async Task<HttpStatusCode> UpdateOrderStatus([FromBody] POrderStatusUpdate status)
        {
            if (status.orderId < 0) throw new Exception("Invalid Id");
            return await _printerOrders.OrderStatusById(status.orderId, status.OutForDeliver, status.PStatus);
        }
    }
}
