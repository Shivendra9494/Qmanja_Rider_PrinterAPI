using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Qmanja_DAL.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Qmanja_BAL.Printer_BAL
{
    public class BLLPrinterOrders : IBLLPrinterOrders
    {
        #region Private Properties
        private readonly QFoodsContext _qFoodsContext;
        private readonly IMapper _mapper;
        #endregion Private Properties

        #region Constructor
        public BLLPrinterOrders(QFoodsContext qFoodsContext, IMapper mapper)
        {
            _qFoodsContext = qFoodsContext;
            _mapper = mapper;
        }
        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Return all orders
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetOrdersAsync()
        {
            var orders = await _qFoodsContext.Orders
                .Include(o => o.OrderItems)
                .OrderByDescending(o => o.CreationDate)
                .ToListAsync();

            return orders;
        }

        /// <summary>
        /// Return all In-Kitchen orders
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetInKitchenOrdersAsync()
        {
            var orders = await _qFoodsContext.Orders
                .Where(o => o.PrinterStatus == "Accepted")
                .OrderByDescending(o => o.CreationDate)
                .ToListAsync();

            return orders;
        }

        /// <summary>
        /// Return all Out-For-Delivery orders
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetOutForDeliveryOrdersAsync()
        {
            var orders = await _qFoodsContext.Orders
                .Where(o => o.OutForDelivery)
                .OrderByDescending(o => o.CreationDate)
                .ToListAsync();

            return orders;
        }

        /// <summary>
        /// Put: Accept Order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deliveryTime"></param>
        /// <param name="responceFromPrinter"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> AcceptOrderAsync
            (int id, string deliveryTime, string responceFromPrinter)
        {
            var order = _qFoodsContext.Orders.Where(o => o.Id == id).FirstOrDefault();

            if (order == null) return HttpStatusCode.NotFound;

            order.DeliveryTime = deliveryTime;
            order.DeliveredDate = DateTime.UtcNow.ToString();
            order.ResponceFromPrinter = responceFromPrinter;
            order.Printed = true;
            order.Acknowledged = true;
            order.PrinterStatus = "Accepted";
            order.Cancelled = false;

            try
            {
                _qFoodsContext.Orders.Update(order);
                await _qFoodsContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return HttpStatusCode.OK;
        }

        /// <summary>
        /// Put: Accept Order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancelTime"></param>
        /// <param name="CancelledBy"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> CancelOrderAsync
            (int id, DateTime cancelTime, string CancelledBy)
        {
            var order = _qFoodsContext.Orders.Where(o => o.Id == id).FirstOrDefault();

            if (order == null) return HttpStatusCode.NotFound;
            order.CancelledDate = DateTime.Now;
            order.CancelledBy = CancelledBy;
            order.ResponceFromPrinter = "Cancelled";
            order.Printed = true;
            order.Acknowledged = true;
            order.PrinterStatus = "Cancelled";
            order.Cancelled = true;

            try
            {
                _qFoodsContext.Orders.Update(order);
                await _qFoodsContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return HttpStatusCode.OK;
        }
        /// <summary>
        /// Put: Accept Order
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="RiderLat"></param>
        /// <param name="Riderlong"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> RiderLoctionAddAsync
            (int orderid, decimal RiderLat, decimal Riderlong)
        {
            var order = _qFoodsContext.Orders.Where(o => o.Id == orderid).FirstOrDefault();

            if (order == null) return HttpStatusCode.NotFound;
            if(order.RiderLatitude != null)
            {
                order.RiderLatitude = RiderLat;
                order.RiderLongitude = Riderlong;
                try
                {
                    _qFoodsContext.Orders.Update(order);
                    await _qFoodsContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                order.RiderLatitude = RiderLat;
                order.RiderLongitude = Riderlong;
                try
                {
                    _qFoodsContext.Orders.Update(order);
                    await _qFoodsContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
           

            return HttpStatusCode.OK;
        }

        /// <summary>
        /// Return order details
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<Order> GetById(int orderId)
        {
            var order = await _qFoodsContext.Orders.Include(o => o.OrderItems).Where(o => o.Id == orderId).FirstOrDefaultAsync();
            if (order == null) throw new Exception("Order not Found!");

            return order;
        }

          public async Task<Order> OrderStatusById(int orderId, bool outofdelivery, string Status)
        {
            var order = _qFoodsContext.Orders.Where(o => o.Id == orderId).FirstOrDefault();
            if (order == null) throw new Exception("Order not Found!");
            else
            {
                order.OutForDelivery = outofdelivery;
                order.PrinterStatus = Status;
            }

            try
            {
                _qFoodsContext.Orders.Update(order);
                await _qFoodsContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return order;
        }


        /// <summary>
        /// Return newely arrived order or null
        /// </summary>
        /// <returns></returns>
        public async Task<Order> CheckForNewOrder()
        {
            var order = await _qFoodsContext.Orders.Where(
                o => o.Acknowledged == false &&
                o.Status == "Sent To Printer" &&
                o.Printed == false &&
                o.OutForDelivery == false &&
                o.Cancelled == false)
            .Include(o => o.OrderItems)
            .OrderByDescending(o => o.CreationDate)
            .FirstOrDefaultAsync();

            return order;
        }

        #endregion Public Method

        #region Private Methods

        #endregion Private Methods
    }
}
