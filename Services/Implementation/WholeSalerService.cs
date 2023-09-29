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
    public class WholeSalerService : IWholeSalerService
    {

        public readonly Repository<WholeSaler> _wholeSalerRepository;

        public readonly IConfiguration _configuration;

        public WholeSalerService(IConfiguration configuration)
        {
            _configuration = configuration;
            var context = new BreweryManagementEntities(_configuration);
            _wholeSalerRepository = new Repository<WholeSaler>(context);
        }

        public void AddWholeSaler(WholeSaler wholeSaler)
        {
            _wholeSalerRepository.Insert(wholeSaler);
        }

        public void Delete(int id)
        {
            _wholeSalerRepository.Delete(id);
        }

        public List<WholeSaler> GetAllWholeSalers()
        {
            var result = _wholeSalerRepository.Get().ToList();

            if (result == null || result.Count == 0)
                return null;

            return result;
        }

        public WholeSaler GetWholeSalerById(int id)
        {
            var result = _wholeSalerRepository.GetByID(id);

            if (result == null)
                return null;

            return result;
        }

        public WholeSaler GetWholeSalerByKey(Expression<Func<WholeSaler, bool>> filter = null)
        {
            var result = _wholeSalerRepository.Get(filter).ToList();

            if (result == null || result.Count == 0)
                return null;

            return result.FirstOrDefault();
        }

        public void Update(int id, WholeSaler wholeSaler)
        {
            wholeSaler.Id = id;
            _wholeSalerRepository.Update(wholeSaler);
        }
    }
}
