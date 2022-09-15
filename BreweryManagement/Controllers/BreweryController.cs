using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreweryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweryController : ControllerBase
    {
        private readonly IBreweryBussinessService _breweryBussinessService;

        public BreweryController(IBreweryBussinessService breweryBussinessService)
        {
            _breweryBussinessService = breweryBussinessService;
        }


        // GET: api/<BreweryController>
        [HttpGet]
        public IEnumerable<BreweryDto> Get()
        {
            return _breweryBussinessService.GetAllBreweries();
        }

        // GET api/<BreweryController>/5
        [HttpGet("{sourceId}")]
        public BreweryDto Get(string sourceId)
        {
            return _breweryBussinessService.GetBreweryByKey(x => x.SourceId == sourceId);
        }

        // POST api/<BreweryController>
        [HttpPost]
        public void Post([FromBody] BreweryDto breweryDto)
        {
            _breweryBussinessService.AddBrewery(breweryDto);
        }

        // PUT api/<BreweryController>/5
        [HttpPut]
        public void Put([FromBody] BreweryDto breweryDto)
        {
            _breweryBussinessService.Update(breweryDto);
        }

        // DELETE api/<BreweryController>/5
        [HttpDelete("{identificationNumber}/{sourceId}")]
        public void Delete(Int64 identificationNumber, string sourceId)
        {
            _breweryBussinessService.SoftDelete(sourceId,identificationNumber);
        }
    }
}
