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
    public interface IBrewerService
    {
        List<Brewer> GetAllBrewers();

        Brewer GetBrewerById(int id);

        void AddBrewer(Brewer brewer);

        void Update(int id, Brewer brewer);

        void Delete(int id);

        Brewer GetBrewerByKey(Expression<Func<Brewer, bool>> filter = null);
    }
}
