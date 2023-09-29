using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStockService
    {
        List<Stock> GetAllStock();

        Stock GetStockById(int id);

        void AddStock(Stock stock);

        void Update(Stock stock);

        void Delete(int id);

        Stock GetStockByKey(Expression<Func<Stock, bool>> filter = null);
    }
}
