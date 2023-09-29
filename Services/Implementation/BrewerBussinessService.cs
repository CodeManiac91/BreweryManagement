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
    public class BrewerBussinessService : IBrewerBussinessService
    {
        private readonly IBrewerService _brewerService;
        private readonly IMapper _mapper;

        public BrewerBussinessService(IBrewerService brewerService, IMapper mapper)
        {
            _brewerService = brewerService;
            _mapper = mapper;
        }

        public void AddBrewer(BrewerDto brewerDto)
        {
            var brewerEntity = _brewerService.GetBrewerByKey(x => x.IndentificationNumber == brewerDto.IdentificationNumber);

            if (brewerEntity != null)
                throw new Exception($"Brewer with IdentificationNumber: {brewerDto.IdentificationNumber} already exist");

            brewerEntity = _mapper.Map<Brewer>(brewerDto);
            _brewerService.AddBrewer(brewerEntity);
        }

        public void Delete(int id)
        {
            _brewerService.Delete(id);
        }

        public List<BrewerDto> GetAllBrewers()
        {
            var result = _brewerService.GetAllBrewers();
            if (result == null || result.Count == 0)
                return null;

            return _mapper.Map<List<BrewerDto>>(result);
        }

        public BrewerDto GetBrewerById(int id)
        {
            var result = _brewerService.GetBrewerById(id);
            if (result == null)
                return null;

            return _mapper.Map<BrewerDto>(result);
        }

        public BrewerDto GetBrewerByKey(Expression<Func<Brewer, bool>> filter = null)
        {
            var result = _brewerService.GetBrewerByKey(filter);
            if (result == null)
                return null;

            return _mapper.Map<BrewerDto>(result);
        }

        public void SoftDelete(long identificationNumber)
        {
            var brewerEntity = _brewerService.GetBrewerByKey(x => x.IndentificationNumber == identificationNumber);

            if (brewerEntity == null)
                throw new Exception($"Brewer with Identification Number: {identificationNumber} was not found");

            brewerEntity.Removed = true;
            _brewerService.Update(brewerEntity.Id, brewerEntity);
        }

        public void Update(BrewerDto brewerDto)
        {
            var brewerEntity = _brewerService.GetBrewerByKey(x => x.IndentificationNumber == brewerDto.IdentificationNumber);
           
            if (brewerEntity == null)
                throw new Exception($"Brewer with Identification Number: {brewerDto.IdentificationNumber} was not found");
           
            brewerEntity.Name = brewerDto.Name;
            brewerEntity.Removed = brewerDto.Removed;
            _brewerService.Update(brewerEntity.Id, brewerEntity);
        }
    }
}
