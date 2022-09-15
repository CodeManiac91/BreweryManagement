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
    public interface IBreweryBussinessService
    {
        List<BreweryDto> GetAllBreweries();

        BreweryDto GetBreweryById(int id);

        void AddBrewery(BreweryDto breweryDto);

        void Update(BreweryDto breweryDto);

        void Delete(int id);

        BreweryDto GetBreweryByKey(Expression<Func<Brewery, bool>> filter = null);

        void SoftDelete(string sourceId, Int64 identificationNumber);
    }
}
