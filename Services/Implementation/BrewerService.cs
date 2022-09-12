using AutoMapper;
using DataAccess;
using DataAccess.Repository;
using DataTransferObjects;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class BrewerService : IBrewerService
    {
        public readonly Repository<Brewer> _brewerRepository;
        public readonly IMapper _mapper;
        public readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        public BrewerService(IMapper mapper, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _configuration = configuration;
            var context = new BreweryManagementEntities(_configuration);           
            _brewerRepository = new Repository<Brewer>(context);
            _mapper = mapper;
            
        }

        public void AddBrewer(BrewerDto brewerDto)
        {
            var brewerEntity = _mapper.Map<Brewer>(brewerDto);
            _brewerRepository.Insert(brewerEntity);
        }

        public void Delete(int id)
        {
            _brewerRepository.Delete(id);
        }

        public List<BrewerDto> GetAllBrewers()
        {
            var result = _brewerRepository.Get().ToList();

            if (result == null || result.Count == 0)
                return null;

            return _mapper.Map<List<BrewerDto>>(result);
        }

        public BrewerDto GetBrewerById(int id)
        {
            var result = _brewerRepository.GetByID(id);

            if (result == null)
                return null;

            return _mapper.Map<BrewerDto>(result);
        }

        public void Update(int id, BrewerDto brewerDto)
        {
            var brewerEntity = _mapper.Map<Brewer>(brewerDto);
            brewerEntity.Id = id;

            _brewerRepository.Update(brewerEntity);
        }
    }
}
