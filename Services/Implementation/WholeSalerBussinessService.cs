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
