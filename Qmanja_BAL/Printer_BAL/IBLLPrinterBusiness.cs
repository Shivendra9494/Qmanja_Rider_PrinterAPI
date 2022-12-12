using Qmanja_DAL.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qmanja_BAL.Printer_BAL
{
    public interface IBLLPrinterBusiness
    {
        Task<BusinessDetail> GetBusinessDetails(int businessid);
        Task<List<Order>> GetTotalSalesDetails(int businessid);
    }
}
