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
    public class BeerBussinessService : IBeerBussinessService
    {
        private readonly IBreweryService _breweryService;
        private readonly IBrewerService _brewerService;
        private readonly IBeerService _beerService;
        private readonly IMapper _mapper;

        public BeerBussinessService(IBreweryService breweryService, IBrewerService brewerService, IBeerService beerService, IMapper mapper)
        {
            _breweryService = breweryService;
            _brewerService = brewerService;
            _beerService = beerService;
            _mapper = mapper;
        }
        public void AddBeer(BeerDto beerDto)
        {
            var brewerEntity = _brewerService.GetBrewerByKey(x => x.IndentificationNumber == beerDto.BrewerIdentificationNumber &&
                                                                  !x.Removed);

            var breweryEntity = _breweryService.GetBreweryByKey(x => x.SourceId == beerDto.BrewerySourceId);

            var beerEntity = _beerService.GetBeerByKey(x => x.SourceId == beerDto.SourceId);

            if (brewerEntity == null || brewerEntity.Removed)
                throw new Exception($"Brewer with Identification Number: {beerDto.BrewerIdentificationNumber} was not found or is not active");

            if (breweryEntity == null || breweryEntity.Removed)
                throw new Exception($"Brewery with Source Id: {beerDto.BrewerySourceId} was not found or is not active");

            if (beerEntity != null)
                throw new Exception($"Beer with Source Id: {beerDto.SourceId} already exist");

            beerEntity = _mapper.Map<Beer>(beerDto);
            beerEntity.BreweryId = breweryEntity.Id;

            _beerService.AddBeer(beerEntity, brewerEntity.Id);
        }

        public void Delete(int id)
        {
            _breweryService.Delete(id);
        }

        public List<BeerDto> GetAllBeers()
        {
            var result = _beerService.GetAllBeers();
            if (result == null || result.Count == 0)
                return null;

            return _mapper.Map<List<BeerDto>>(result);
        }

        public BeerDto GetBeerById(int id)
        {
            var result = _beerService.GetBeerById(id);
            if (result == null)
                return null;

            return _mapper.Map<BeerDto>(result);
        }

        public BeerDto GetBeerByKey(Expression<Func<Beer, bool>> filter = null)
        {
            var result = _beerService.GetBeerByKey(filter);
            if (result == null)
                return null;

            return _mapper.Map<BeerDto>(result);
        }

        public void SoftDelete(string sourceId, long identificationNumber)
        {
            var brewerEntity = _brewerService.GetBrewerByKey(x => x.IndentificationNumber == identificationNumber);
            var beerEntity = _beerService.GetBeerByKey(x => x.SourceId == sourceId);

            if (brewerEntity == null || brewerEntity.Removed)
                throw new Exception($"Brewer with Identification Number: {identificationNumber} was not found or is not active");

            if (beerEntity == null)
                throw new Exception($"Beer with Source Id: {sourceId} was not found");

            beerEntity.Removed = true;
            _beerService.Update(beerEntity.Id, beerEntity, brewerEntity.Id);
        }

        public void Update(BeerDto beerDto)
        {
            var brewerEntity = _brewerService.GetBrewerByKey(x => x.IndentificationNumber == beerDto.BrewerIdentificationNumber);
            var breweryEntity = _breweryService.GetBreweryByKey(x => x.SourceId == beerDto.BrewerySourceId);
            var beerEntity = _beerService.GetBeerByKey(x => x.SourceId == beerDto.SourceId);

            if (brewerEntity == null || brewerEntity.Removed)
                throw new Exception($"Brewer with Identification Number: {beerDto.BrewerIdentificationNumber} was not found or is not active");

            if (breweryEntity == null || breweryEntity.Removed)
                throw new Exception($"Brewery with Source Id: {beerDto.BrewerySourceId} was not found or is not active");

            if (beerEntity == null)
                throw new Exception($"Beer with Source Id: {beerDto.SourceId} was not found");


            beerEntity.Name = beerDto.Name;
            beerEntity.AlcoholContent = beerDto.AlcoholContent;
            beerEntity.BreweryId = breweryEntity.Id;
            beerEntity.Removed = beerDto.Removed;

            _beerService.Update(beerEntity.Id, beerEntity, brewerEntity.Id);
        }
    }
}
