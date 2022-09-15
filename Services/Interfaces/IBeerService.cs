using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBeerService
    {
        List<Beer> GetAllBeers();

        Beer GetBeerById(int id);

        void AddBeer(Beer beer, int brewerId);

        void Update(int id, Beer beer, int brewerId);

        void Delete(int id);

        Beer GetBeerByKey(Expression<Func<Beer, bool>> filter = null);
    }
}
