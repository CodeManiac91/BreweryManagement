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
    public class StockBussinessService : IStockBussinessService
    {
        private readonly IBrewerService _brewerService;
        private readonly IBeerService _beerService;
        private readonly IStockService _stockService;
        private readonly IWholeSalerService _wholeSalerService;
        private readonly IMapper _mapper;

        public StockBussinessService(IBrewerService brewerService, IBeerService beerService, IStockService stockService, IWholeSalerService wholeSalerService, IMapper mapper)
        {
            _brewerService = brewerService;
            _beerService = beerService;
            _stockService = stockService;
            _wholeSalerService = wholeSalerService;
            _mapper = mapper;
        }

        public void AddStock(StockDto stockDto)
        { 
            var beerEntity = _beerService.GetBeerByKey(x => x.SourceId == stockDto.BeerSourceId);

            var wholeSalerEntity = _wholeSalerService.GetWholeSalerByKey(x => x.SourceId == stockDto.WholeSalerSourceId);

            if (beerEntity == null || beerEntity.Removed)
                throw new Exception($"Beer with Source Id: {stockDto.BeerSourceId} was not found or is not active");

            if (wholeSalerEntity == null || wholeSalerEntity.Removed)
                throw new Exception($"WholeSaler with Source Id: {stockDto.WholeSalerSourceId} was not found or is not active");

            var stockEntity = _stockService.GetStockByKey(x => x.WholeSalerId == wholeSalerEntity.Id
                                                            && x.BeerId == beerEntity.Id);

            if (stockEntity != null)
                throw new Exception($"Stock already exist");

            stockEntity = _mapper.Map<Stock>(stockDto);
            stockEntity.BeerId = beerEntity.Id;
            stockEntity.WholeSalerId = wholeSalerEntity.Id;

            _stockService.AddStock(stockEntity);
        }

        public void Delete(int id)
        {
            _stockService.Delete(id);
        }

        public List<StockDto> GetAllStocks()
        {
            var result = _stockService.GetAllStock();
            if (result == null || result.Count == 0)
                return null;

            return _mapper.Map<List<StockDto>>(result);
        }

        public StockDto GetStockById(int id)
        {
            var result = _stockService.GetStockById(id);
            if (result == null)
                return null;

            return _mapper.Map<StockDto>(result);
        }

        public StockDto GetStockByKey(Expression<Func<Stock, bool>> filter = null)
        {
            var result = _stockService.GetStockByKey(filter);
            if (result == null)
                return null;

            return _mapper.Map<StockDto>(result);
        }

        public void HardDelete(string beerSourceId, string wholeSalerSourceId)
        {
            var beerEntity = _beerService.GetBeerByKey(x => x.SourceId == beerSourceId);

            var wholeSalerEntity = _wholeSalerService.GetWholeSalerByKey(x => x.SourceId == wholeSalerSourceId);

            if (beerEntity == null || beerEntity.Removed)
                throw new Exception($"Beer with Source Id: {beerSourceId} was not found or is not active");

            if (wholeSalerEntity == null || wholeSalerEntity.Removed)
                throw new Exception($"WholeSaler with Source Id: {wholeSalerSourceId} was not found or is not active");

            var stockEntity = _stockService.GetStockByKey(x => x.WholeSalerId == wholeSalerEntity.Id
                                                            && x.BeerId == beerEntity.Id);

            if (stockEntity == null)
                throw new Exception($"Stock does not exist");

            _stockService.Delete(stockEntity.Id);
        }

        public void Update(StockDto stockDto)
        {
            var beerEntity = _beerService.GetBeerByKey(x => x.SourceId == stockDto.BeerSourceId);

            var wholeSalerEntity = _wholeSalerService.GetWholeSalerByKey(x => x.SourceId == stockDto.WholeSalerSourceId);

            if (beerEntity == null || beerEntity.Removed)
                throw new Exception($"Beer with Source Id: {stockDto.BeerSourceId} was not found or is not active");

            if (wholeSalerEntity == null || wholeSalerEntity.Removed)
                throw new Exception($"WholeSaler with Source Id: {stockDto.WholeSalerSourceId} was not found or is not active");

            var stockEntity = _stockService.GetStockByKey(x => x.WholeSalerId == wholeSalerEntity.Id
                                                            && x.BeerId == beerEntity.Id);

            if (stockEntity == null)
                throw new Exception($"Stock does not exist");

            stockEntity.Amount = stockDto.Amount;

            _stockService.Update(stockEntity);
        }
    }
}
