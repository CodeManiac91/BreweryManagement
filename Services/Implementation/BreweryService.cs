using DataAccess.Repository;
using DataAccess;
using DataTransferObjects;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;

namespace Services.Implementation
{
    public class BreweryService : IBreweryService
    {
        public readonly Repository<Brewery> _breweryRepository;
        public readonly IConfiguration _configuration;
        public readonly IAuditService _auditService;
    
        public BreweryService(IConfiguration configuration, IAuditService auditService)
        {
            _configuration = configuration;
            var context = new BreweryManagementEntities(_configuration);
            _breweryRepository = new Repository<Brewery>(context);
            _auditService = auditService;
        }

        public void AddBrewery(Brewery brewery, int brewerId)
        {            
            brewery = _auditService.PopulateAuditFields<Brewery>(brewery, brewerId);
            _breweryRepository.Insert(brewery);
        }

        public void Delete(int id)
        {
            _breweryRepository.Delete(id);
        }

        public List<Brewery> GetAllBreweries()
        {
            var result = _breweryRepository.Get().ToList();

            if (result == null || result.Count == 0)
                return null;

            return result;
        }

        public Brewery GetBreweryById(int id)
        {
            var result = _breweryRepository.GetByID(id);

            if (result == null)
                return null;

            return result;
        }

        public Brewery GetBreweryByKey(Expression<Func<Brewery, bool>> filter = null)
        {
            var result = _breweryRepository.Get(filter).ToList();

            if (result == null || result.Count == 0)
                return null;

            return result.FirstOrDefault();
        }

        public void Update(int id, Brewery brewery,int brewerId)
        {
            brewery.Id = id;
            brewery = _auditService.PopulateAuditFields<Brewery>(brewery, brewerId,true);
            _breweryRepository.Update(brewery);
        }
    }
}
