﻿using AutoMapper;
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
                .Where(o => o.Acknowledged)
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
            order.Status = "Accepted";
            order.Cancelled = false;

            try
            {
                _qFoodsContext.Orders.Add(order);
                await _qFoodsContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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