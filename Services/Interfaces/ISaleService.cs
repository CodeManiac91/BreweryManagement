using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISaleService
    {
        List<Sale> GetAllSales();

        Sale GetSaleById(int id);

        void AddSale(Sale sale, int brewerId);

        void Update(Sale sale, int brewerId);

        void Delete(int id);

        Sale GetSaleByKey(Expression<Func<Sale, bool>> filter = null);
    }
}
