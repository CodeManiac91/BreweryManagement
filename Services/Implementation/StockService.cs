using DataAccess.Repository;
using DataAccess;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace Services.Implementation
{
    public class StockService : IStockService
    {
        public readonly Repository<Stock> _stockRepository;
        public readonly IConfiguration _configuration;

        public StockService(IConfiguration configuration)
        {
            _configuration = configuration;
            var context = new BreweryManagementEntities(_configuration);
            _stockRepository = new Repository<Stock>(context);
        }

        public void AddStock(Stock stock)
        {
            _stockRepository.Insert(stock);
        }

        public void Delete(int id)
        {
            _stockRepository.Delete(id);
        }

        public List<Stock> GetAllStock()
        {
            var result = _stockRepository.Get().ToList();

            if (result == null || result.Count == 0)
                return null;

            return result;
        }

        public Stock GetStockById(int id)
        {
            var result = _stockRepository.GetByID(id);

            if (result == null)
                return null;

            return result;
        }

        public Stock GetStockByKey(Expression<Func<Stock, bool>> filter = null)
        {
            var result = _stockRepository.Get(filter).ToList();

            if (result == null || result.Count == 0)
                return null;

            return result.FirstOrDefault();
        }

        public void Update(Stock stock)
        {
            _stockRepository.Update(stock);
        }
    }
}
