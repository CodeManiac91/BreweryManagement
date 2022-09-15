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
    public interface IBreweryService
    {
        List<Brewery> GetAllBreweries();

        Brewery GetBreweryById(int id);

        void AddBrewery(Brewery brewery, int brewerId);

        void Update(int id, Brewery brewery, int brewerId);

        void Delete(int id);

        Brewery GetBreweryByKey(Expression<Func<Brewery, bool>> filter = null);
    }
}
