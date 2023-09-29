using DataAccess;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class BeerService : IBeerService
    {
        public readonly Repository<Beer> _beerRepository;
        public readonly IConfiguration _configuration;
        public readonly IAuditService _auditService;

        public BeerService(IConfiguration configuration, IAuditService auditService)
        {
            _configuration = configuration;
            var context = new BreweryManagementEntities(_configuration);
            _beerRepository = new Repository<Beer>(context);
            _auditService = auditService;
        }

        public void AddBeer(Beer beer, int brewerId)
        {
            beer = _auditService.PopulateAuditFields<Beer>(beer, brewerId);
            _beerRepository.Insert(beer);
        }

        public void Delete(int id)
        {
            _beerRepository.Delete(id);
        }

        public List<Beer> GetAllBeers()
        {
            var result = _beerRepository.Get().ToList();

            if (result == null || result.Count == 0)
                return null;

            return result;
        }

        public Beer GetBeerById(int id)
        {
            var result = _beerRepository.GetByID(id);

            if (result == null)
                return null;

            return result;
        }

        public Beer GetBeerByKey(Expression<Func<Beer, bool>> filter = null)
        {
            var result = _beerRepository.Get(filter).ToList();

            if (result == null || result.Count == 0)
                return null;

            return result.FirstOrDefault();
        }

        public void Update(int id, Beer beer, int brewerId)
        {
            beer.Id = id;
            beer = _auditService.PopulateAuditFields<Beer>(beer, brewerId, true);
            _beerRepository.Update(beer);
        }
    }
}
