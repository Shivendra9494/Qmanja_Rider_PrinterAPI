using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qmanja_BAL.Printer_BAL;
using Qmanja_DAL.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rider_Printer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PSyncOrderController : ControllerBase
    {
        private readonly IBLLPrinterOrders _printerOrders;
        //  BLLPrinterMenuItems _printerMenu = new BLLPrinterMenuItems();

        public PSyncOrderController(IBLLPrinterOrders printerOrders)
        {
            _printerOrders = printerOrders;
        }


    
        [Microsoft.AspNetCore.Mvc.HttpGet("FetchNewOrder")]
        public async Task<Order> GetNewOrder()
        {
            return await _printerOrders.CheckForNewOrder();
        }
    }
}
