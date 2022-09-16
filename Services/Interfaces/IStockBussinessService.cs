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
    public interface IStockBussinessService
    {
        List<StockDto> GetAllStocks();

        StockDto GetStockById(int id);

        void AddStock(StockDto stockDto);

        void Update(StockDto stockDto);

        void Delete(int id);

        StockDto GetStockByKey(Expression<Func<Stock, bool>> filter = null);

        void HardDelete(string beerSourceId, string wholeSalerSourceId);
    }
}
