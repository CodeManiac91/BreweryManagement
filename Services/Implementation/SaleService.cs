using DataAccess;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.PeerToPeer.Collaboration;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class SaleService : ISaleService
    {
        public readonly Repository<Sale> _saleRepository;
        public readonly IAuditService _auditService;
        public readonly IConfiguration _configuration;

        public SaleService(IConfiguration configuration, IAuditService auditService)
        {
            _configuration = configuration;
            var context = new BreweryManagementEntities(_configuration);
            _saleRepository = new Repository<Sale>(context);
            _auditService = auditService;
        }

        public void AddSale(Sale sale, int brewerId)
        {
            sale = _auditService.PopulateAuditFields<Sale>(sale, brewerId);
            _saleRepository.Insert(sale);
        }

        public void Delete(int id)
        {
            _saleRepository.Delete(id);
        }

        public List<Sale> GetAllSales()
        {
            var result = _saleRepository.Get().ToList();

            if (result == null || result.Count == 0)
                return null;

            return result;
        }

        public Sale GetSaleById(int id)
        {
            var result = _saleRepository.GetByID(id);

            if (result == null)
                return null;

            return result;
        }

        public Sale GetSaleByKey(Expression<Func<Sale, bool>> filter = null)
        {
            var result = _saleRepository.Get(filter).ToList();

            if (result == null || result.Count == 0)
                return null;

            return result.FirstOrDefault();
        }

        public void Update(Sale sale, int brewerId)
        {
            sale = _auditService.PopulateAuditFields<Sale>(sale, brewerId, true);
            _saleRepository.Update(sale);
        }
    }
}
