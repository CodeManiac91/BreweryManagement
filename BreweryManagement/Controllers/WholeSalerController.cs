using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreweryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WholeSalerController : ControllerBase
    {
        private readonly IWholeSalerBussinessService _wholeSalerBussinessService;

        public WholeSalerController(IWholeSalerBussinessService wholeSalerBussinessService)
        {
            _wholeSalerBussinessService = wholeSalerBussinessService;
        }



        // GET: api/<WholeSalerController>
        [HttpGet]
        public IEnumerable<WholeSalerDto> Get()
        {
            return _wholeSalerBussinessService.GetAllWholeSalers();
        }

        // GET api/<WholeSalerController>/5
        [HttpGet("{sourceId}")]
        public WholeSalerDto Get(string sourceId)
        {
            return _wholeSalerBussinessService.GetWholeSalerByKey(x => x.SourceId == sourceId);
        }

        // POST api/<WholeSalerController>
        [HttpPost]
        public void Post([FromBody] WholeSalerDto wholeSalerDto)
        {
            _wholeSalerBussinessService.AddWholeSaler(wholeSalerDto);
        }

        // PUT api/<WholeSalerController>/5
        [HttpPut]
        public void Put([FromBody] WholeSalerDto wholeSalerDto)
        {
            _wholeSalerBussinessService.Update(wholeSalerDto);
        }

        // DELETE api/<WholeSalerController>/5
        [HttpDelete("{sourceId}")]
        public void Delete(string sourceId)
        {
            _wholeSalerBussinessService.SoftDelete(sourceId);
        }
    }
}
