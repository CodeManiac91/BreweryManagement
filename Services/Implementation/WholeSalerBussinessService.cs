using AutoMapper;
using DataAccess;
using DataTransferObjects;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class WholeSalerBussinessService : IWholeSalerBussinessService
    {
        private readonly IWholeSalerService _wholeSalerService;
        private readonly IMapper _mapper;

        public WholeSalerBussinessService(IWholeSalerService wholeSalerService, IMapper mapper)
        {
            _wholeSalerService = wholeSalerService;
            _mapper = mapper;
        }
        public void AddWholeSaler(WholeSalerDto wholeSalerDto)
        {
            var wholeSalerEntity = _wholeSalerService.GetWholeSalerByKey(x => x.SourceId == wholeSalerDto.SourceId);

            if (wholeSalerEntity != null)
                throw new Exception($"WholeSalerEntity with SourceId: {wholeSalerDto.SourceId} already exist");

            wholeSalerEntity = _mapper.Map<WholeSaler>(wholeSalerDto);
            _wholeSalerService.AddWholeSaler(wholeSalerEntity);
        }

        public void Delete(int id)
        {
            _wholeSalerService.Delete(id);
        }

        public List<WholeSalerDto> GetAllWholeSalers()
        {
            var result = _wholeSalerService.GetAllWholeSalers();
            if (result == null || result.Count == 0)
                return null;

            return _mapper.Map<List<WholeSalerDto>>(result);
        }

        public QuoteResponseDto GetQuoteDetails(QuoteRequestDto quoteRequestDto)
        {
            var groupedBeers = quoteRequestDto.BeerList.GroupBy(x => x.SourceId).ToList();

            if (groupedBeers.Any(x => x.Count() > 1))
                throw new Exception($"There are beer(s) duplicated in beer list");

            var wholeSalerEntity = _wholeSalerService.GetWholeSalerByKey(x => x.SourceId == quoteRequestDto.WholeSalerSourceId);

            if (wholeSalerEntity == null)
                throw new Exception($"WholeSalerEntity with SourceId: {quoteRequestDto.WholeSalerSourceId} was not found");

            var quoteResponseDto = new QuoteResponseDto();

            quoteResponseDto.WholeSalerName = wholeSalerEntity.Name;
            quoteResponseDto.WholeSalerSourceId = wholeSalerEntity.SourceId;

            foreach (var item in quoteRequestDto.BeerList)
            {
                var stockEntity = wholeSalerEntity.Stocks.Where(x => x.Beer.SourceId == item.SourceId).FirstOrDefault();
                
                if (stockEntity == null)
                    throw new Exception($"Beer with SourceId: {item.SourceId} was not found in the stock");

                if(stockEntity.Amount < item.Amount)
                    throw new Exception($"Beer stock amount is lower than provided");

                quoteResponseDto.TotalAmmountOfBeers += item.Amount;
                quoteResponseDto.TotalPrice += stockEntity.Beer.Price * item.Amount;
                quoteResponseDto.BeerList.Add(item);
            }

            if(quoteResponseDto.TotalAmmountOfBeers > 10)
                quoteResponseDto.TotalPriceWithDiscount = quoteResponseDto.TotalPrice % 10;
            if (quoteResponseDto.TotalAmmountOfBeers > 20)
                quoteResponseDto.TotalPriceWithDiscount = quoteResponseDto.TotalPrice % 20;


            return quoteResponseDto;
        }

        public WholeSalerDto GetWholeSalerById(int id)
        {
            var result = _wholeSalerService.GetWholeSalerById(id);
            if (result == null)
                return null;

            return _mapper.Map<WholeSalerDto>(result);
        }

        public WholeSalerDto GetWholeSalerByKey(Expression<Func<WholeSaler, bool>> filter = null)
        {
            var result = _wholeSalerService.GetWholeSalerByKey(filter);
            if (result == null)
                return null;

            return _mapper.Map<WholeSalerDto>(result);
        }

        public void SoftDelete(string sourceId)
        {
            var wholeSalerEntity = _wholeSalerService.GetWholeSalerByKey(x => x.SourceId ==sourceId);

            if (wholeSalerEntity == null)
                throw new Exception($"WholeSalerEntity with SourceId: {sourceId} was not found");

            wholeSalerEntity.Removed = true;
            _wholeSalerService.Update(wholeSalerEntity.Id, wholeSalerEntity);
        }

        public void Update(WholeSalerDto wholeSalerDto)
        {
            var wholeSalerEntity = _wholeSalerService.GetWholeSalerByKey(x => x.SourceId == wholeSalerDto.SourceId);

            if (wholeSalerEntity == null)
                throw new Exception($"WholeSalerEntity with SourceId: {wholeSalerDto.SourceId} was not found");

            wholeSalerEntity.Name = wholeSalerDto.Name;
            wholeSalerEntity.Removed = wholeSalerDto.Removed;
            _wholeSalerService.Update(wholeSalerEntity.Id, wholeSalerEntity);
        }
    }
}
