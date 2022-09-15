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
    public interface IBeerBussinessService
    {
        List<BeerDto> GetAllBeers();

        BeerDto GetBeerById(int id);

        void AddBeer(BeerDto beerDto);

        void Update(BeerDto beerDto);

        void Delete(int id);

        BeerDto GetBreweryByKey(Expression<Func<Beer, bool>> filter = null);

        void SoftDelete(string sourceId, Int64 identificationNumber);
    }
}
