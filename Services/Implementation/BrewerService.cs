using DataAccess;
using DataAccess.Repository;
using DataTransferObjects;
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
    public class BrewerService : IBrewerService
    {
        public readonly Repository<Brewer> _brewerRepository;

        public readonly IConfiguration _configuration;

        public BrewerService(IConfiguration configuration)
        {
            _configuration = configuration;
            var context = new BreweryManagementEntities(_configuration);           
            _brewerRepository = new Repository<Brewer>(context);      
        }

        public void AddBrewer(Brewer brewer)
        {
            _brewerRepository.Insert(brewer);
        }

        public void Delete(int id)
        {
            _brewerRepository.Delete(id);
        }

        public List<Brewer> GetAllBrewers()
        {
            var result = _brewerRepository.Get().ToList();

            if (result == null || result.Count == 0)
                return null;

            return result;
        }

        public Brewer GetBrewerById(int id)
        {
            var result = _brewerRepository.GetByID(id);

            if (result == null)
                return null;

            return result;
        }

        public void Update(int id, Brewer brewer)
        {
            brewer.Id = id;
            _brewerRepository.Update(brewer);
        }

        public Brewer GetBrewerByKey(Expression<Func<Brewer, bool>> filter = null)
        {
            var result = _brewerRepository.Get(filter).ToList();

            if (result == null || result.Count == 0)
                return null;

            return result.FirstOrDefault();
        }
    }
}
