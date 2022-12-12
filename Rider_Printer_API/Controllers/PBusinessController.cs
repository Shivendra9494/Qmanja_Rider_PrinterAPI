using Microsoft.AspNetCore.Mvc;
using Qmanja_BAL.Printer_BAL;
using Qmanja_DAL.DBModels;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Rider_Printer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PBusinessController : ControllerBase
    {
        private readonly IBLLPrinterBusiness _bLLPrinter;
        //  BLLPrinterMenuItems _printerMenu = new BLLPrinterMenuItems();

        public PBusinessController(IBLLPrinterBusiness bLLPrinter )
        {
            _bLLPrinter = bLLPrinter;
        }

        [HttpGet("businessdetails")]
        public async Task<BusinessDetail> GetBusiness([System.Web.Http.FromUri] int businessid)
        {
            if (businessid < 0) throw new Exception("Invalid Id");
            return await _bLLPrinter.GetBusinessDetails(businessid);
        }

        [HttpGet("GetTotalSalesDetails")]
        public async Task<List<Order>> GetTotalSales([System.Web.Http.FromUri] int businessid)
        {
            if (businessid < 0) throw new Exception("Invalid Id");
            return await _bLLPrinter.GetTotalSalesDetails(businessid);
        }
    }
}
