using AutoMapper;
using DataAccess;
using DataTransferObjects;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class SaleBussinessService : ISaleBussinessService
    {
        private readonly IBreweryService _breweryService;
        private readonly IBrewerService _brewerService;
        private readonly IBeerService _beerService;
        private readonly ISaleService _saleService;
        private readonly IWholeSalerService _wholeSalerService;
        private readonly IMapper _mapper;

        public SaleBussinessService(IBreweryService breweryService, IBrewerService brewerService, IBeerService beerService, ISaleService saleService, IWholeSalerService wholeSalerService, IMapper mapper)
        {
            _breweryService = breweryService;
            _brewerService = brewerService;
            _beerService = beerService;
            _saleService = saleService;
            _wholeSalerService = wholeSalerService;
            _mapper = mapper;
        }

        public void AddSale(SaleDto saleDto)
        {
            var brewerEntity = _brewerService.GetBrewerByKey(x => x.IndentificationNumber == saleDto.BrewerIdentificationNumber);

            var beerEntity = _beerService.GetBeerByKey(x => x.SourceId == saleDto.BeerSourceId);

            var wholeSalerEntity = _wholeSalerService.GetWholeSalerByKey(x => x.SourceId == saleDto.WholeSalerSourceId);

            var saleEntity = _saleService.GetSaleByKey(x => x.SalesOrderNumber == saleDto.SalesOrderNumber);
            
            if (brewerEntity == null || brewerEntity.Removed)
                throw new Exception($"Brewer with Identification Number: {saleDto.BrewerIdentificationNumber} was not found or is not active");

            if (beerEntity == null || beerEntity.Removed)
                throw new Exception($"Beer with Source Id: {saleDto.BeerSourceId} was not found or is not active");

            if (wholeSalerEntity == null || wholeSalerEntity.Removed)
                throw new Exception($"WholeSaler with Source Id: {saleDto.WholeSalerSourceId} was not found or is not active");

            if (saleEntity != null)
                throw new Exception($"Sale with Order Number Id: {saleDto.SalesOrderNumber} already exist");

            saleEntity = _mapper.Map<Sale>(saleDto);
            saleEntity.BeerId = beerEntity.Id;
            saleEntity.WholeSalerId = wholeSalerEntity.Id;

            _beerService.AddBeer(beerEntity, brewerEntity.Id);
        }

        public void Delete(int id)
        {
            _saleService.Delete(id);
        }

        public List<SaleDto> GetAllSales()
        {
            var result = _saleService.GetAllSales();
            if (result == null || result.Count == 0)
                return null;

            return _mapper.Map<List<SaleDto>>(result);
        }

        public SaleDto GetSaleByKey(Expression<Func<Sale, bool>> filter = null)
        {
            var result = _saleService.GetSaleByKey(filter);
            if (result == null)
                return null;

            return _mapper.Map<SaleDto>(result);
        }

        public SaleDto GetSaleById(int id)
        {
            var result = _saleService.GetSaleById(id);
            if (result == null)
                return null;

            return _mapper.Map<SaleDto>(result);
        }

        public void HardDelete(string saleOrderNumber)
        {
            var saleEntity = _saleService.GetSaleByKey(x => x.SalesOrderNumber == saleOrderNumber);

            if (saleEntity == null)
                throw new Exception($"Sale with Order number: {saleOrderNumber} was not found");
            
            _saleService.Delete(saleEntity.Id);
        }

        public void Update(SaleDto saleDto)
        {
            var brewerEntity = _brewerService.GetBrewerByKey(x => x.IndentificationNumber == saleDto.BrewerIdentificationNumber);

            var beerEntity = _beerService.GetBeerByKey(x => x.SourceId == saleDto.BeerSourceId);

            var wholeSalerEntity = _wholeSalerService.GetWholeSalerByKey(x => x.SourceId == saleDto.WholeSalerSourceId);

            var saleEntity = _saleService.GetSaleByKey(x => x.SalesOrderNumber == saleDto.SalesOrderNumber);

            if (brewerEntity == null || brewerEntity.Removed)
                throw new Exception($"Brewer with Identification Number: {saleDto.BrewerIdentificationNumber} was not found or is not active");

            if (beerEntity == null || beerEntity.Removed)
                throw new Exception($"Beer with Source Id: {saleDto.BeerSourceId} was not found or is not active");

            if (wholeSalerEntity == null || wholeSalerEntity.Removed)
                throw new Exception($"WholeSaler with Source Id: {saleDto.WholeSalerSourceId} was not found or is not active");

            if (saleEntity == null)
                throw new Exception($"Sale with Order Number Id: {saleDto.SalesOrderNumber} was not found");

            saleEntity.TotalPrice = saleDto.TotalPrice;
            saleEntity.Amount = saleDto.Amount;
            saleEntity.BeerId = beerEntity.Id;
            saleEntity.WholeSalerId = wholeSalerEntity.Id;

            _saleService.Update(saleEntity, brewerEntity.Id);
        }
    }
}
