using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qmanja_BAL.Printer_BAL;
using Qmanja_DAL.DBModels;
using Rider_Printer_API.ViewModel;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Rider_Printer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PRidersController : ControllerBase
    {
        private readonly IBLLPrinterOrders _printerOrders;
        //  BLLPrinterMenuItems _printerMenu = new BLLPrinterMenuItems();

        public PRidersController(IBLLPrinterOrders printerOrders)
        {
            _printerOrders = printerOrders;
        }

        [HttpPut("RiderLocSave")]
        public async Task<HttpStatusCode> RiderLocSave([FromBody] PRiderLoction rider)
        {
            if (rider == null) return HttpStatusCode.BadRequest;
            return await _printerOrders.RiderLoctionAddAsync(rider.OrderId, rider.RiderLat, rider.RiderLong);

        }
    }
}
