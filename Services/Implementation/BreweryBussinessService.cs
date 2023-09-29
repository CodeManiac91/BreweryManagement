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
    public class BreweryBussinessService : IBreweryBussinessService
    {
        private readonly IBreweryService _breweryService;
        private readonly IBrewerService _brewerService;
        private readonly IMapper _mapper;

        public BreweryBussinessService(IBreweryService breweryService, IBrewerService brewerService, IMapper mapper)
        {
            _breweryService = breweryService;
            _brewerService = brewerService;
            _mapper = mapper;
        }

        public void AddBrewery(BreweryDto breweryDto)
        {
            var brewerEntity = _brewerService.GetBrewerByKey(x => x.IndentificationNumber == breweryDto.BrewerIdentificationNumber &&
                                                                  !x.Removed);

            var breweryEntity = _breweryService.GetBreweryByKey(x => x.SourceId == breweryDto.SourceId);

            if (brewerEntity == null || brewerEntity.Removed)
                throw new Exception($"Brewer with Identification Number: {breweryDto.BrewerIdentificationNumber} was not found or is not active");
            
            if (breweryEntity != null)
                throw new Exception($"Brewery with Source Id: {breweryDto.SourceId} already exist");

             breweryEntity = _mapper.Map<Brewery>(breweryDto);
            _breweryService.AddBrewery(breweryEntity, brewerEntity.Id);
        }

        public void Delete(int id)
        {
            _breweryService.Delete(id);
        }

        public List<BreweryDto> GetAllBreweries()
        {
            var result = _breweryService.GetAllBreweries();
            if (result == null || result.Count == 0)
                return null;

            return _mapper.Map<List<BreweryDto>>(result);
        }

        public BreweryDto GetBreweryById(int id)
        {
            var result = _breweryService.GetBreweryById(id);
            if (result == null)
                return null;

            return _mapper.Map<BreweryDto>(result);
        }

        public BreweryDto GetBreweryByKey(Expression<Func<Brewery, bool>> filter = null)
        {
            var result = _breweryService.GetBreweryByKey(filter);
            if (result == null)
                return null;

            return _mapper.Map<BreweryDto>(result);
        }

        public void Update(BreweryDto breweryDto)
        {
            var brewerEntity = _brewerService.GetBrewerByKey(x => x.IndentificationNumber == breweryDto.BrewerIdentificationNumber);
            var breweryEntity = _breweryService.GetBreweryByKey(x => x.SourceId == breweryDto.SourceId);

            if (brewerEntity == null || brewerEntity.Removed)
                throw new Exception($"Brewer with Identification Number: {breweryDto.BrewerIdentificationNumber} was not found or is not active");

            if(breweryEntity == null)
                throw new Exception($"Brewery with Source Id: {breweryDto.SourceId} was not found");

            breweryEntity.Name = breweryDto.Name;
            breweryEntity.Removed = breweryDto.Removed;

            _breweryService.Update(breweryEntity.Id,breweryEntity, brewerEntity.Id);
        }

        public void SoftDelete(string sourceId, Int64 identificationNumber)
        {
            var brewerEntity = _brewerService.GetBrewerByKey(x => x.IndentificationNumber == identificationNumber);
            var breweryEntity = _breweryService.GetBreweryByKey(x => x.SourceId == sourceId);

            if (brewerEntity == null || brewerEntity.Removed)
                throw new Exception($"Brewer with Identification Number: {identificationNumber} was not found or is not active");

            if (breweryEntity == null)
                throw new Exception($"Brewery with Source Id: {sourceId} was not found");

            breweryEntity.Removed = true;
            _breweryService.Update(breweryEntity.Id, breweryEntity,brewerEntity.Id);
        }
    }
}
