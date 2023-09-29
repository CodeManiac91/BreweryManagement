using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IWholeSalerService
    {
        List<WholeSaler> GetAllWholeSalers();

        WholeSaler GetWholeSalerById(int id);

        void AddWholeSaler(WholeSaler wholeSaler);

        void Update(int id, WholeSaler wholeSaler);

        void Delete(int id);

        WholeSaler GetWholeSalerByKey(Expression<Func<WholeSaler, bool>> filter = null);
    }
}
