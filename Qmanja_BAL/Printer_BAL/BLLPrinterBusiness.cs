using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Qmanja_DAL.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qmanja_BAL.Printer_BAL
{
    public class BLLPrinterBusiness : IBLLPrinterBusiness
    {
        #region Private Properties
        private readonly QFoodsContext _qFoodsContext;
        private readonly IMapper _mapper;
        #endregion Private Properties

        #region Constructor
        public BLLPrinterBusiness(QFoodsContext qFoodsContext, IMapper mapper)
        {
            _qFoodsContext = qFoodsContext;
            _mapper = mapper;
        }
        #endregion Constructor


        /// <summary>
        /// Return order details
        /// </summary> 
        /// <param name="businessid"></param>
        /// <returns></returns>
        public async Task<BusinessDetail> GetBusinessDetails(int businessid)
        {
            var business  = await _qFoodsContext.BusinessDetails.Where(o => o.Id == businessid).FirstOrDefaultAsync();
            if (business == null) throw new Exception("Order not Found!");
            return business;
        }
        /// <summary>
        /// Return order details
        /// </summary> 
        /// <param name="businessid"></param>
        /// <returns></returns>
        public async Task<List<Order>> GetTotalSalesDetails(int businessid)
        {
            var business  = await _qFoodsContext.Orders.Where(o => o.BusinessDetailId == businessid && o.CreationDate >= DateTime.Now.AddMonths(-1)).ToListAsync();
            if (business == null) throw new Exception("Order not Found!");
            return business;
        }
       
    }
}
