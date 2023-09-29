using DataAccess;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISaleBussinessService
    {
        List<SaleDto> GetAllSales();

        SaleDto GetSaleById(int id);

        void AddSale(SaleDto saleDto);

        void Update(SaleDto saleDto);

        void Delete(int id);

        SaleDto GetSaleByKey(Expression<Func<Sale, bool>> filter = null);

        void HardDelete(string sourceId);
    }
}
