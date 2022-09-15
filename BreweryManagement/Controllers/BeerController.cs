using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreweryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerBussinessService _beerBussinessService;

        public BeerController(IBeerBussinessService beerBussinessService)
        {
            _beerBussinessService = beerBussinessService;
        }

        // GET: api/<BeerController>
        [HttpGet]
        public IEnumerable<BeerDto> Get()
        {
            return _beerBussinessService.GetAllBeers();
        }

        // GET api/<BeerController>/5
        [HttpGet("{sourceId}")]
        public BeerDto Get(string sourceId)
        {
            return _beerBussinessService.GetBreweryByKey(x => x.SourceId == sourceId);
        }

        // POST api/<BeerController>
        [HttpPost]
        public void Post([FromBody] BeerDto beerDto)
        {
            _beerBussinessService.AddBeer(beerDto);
        }

        // PUT api/<BeerController>/5
        [HttpPut]
        public void Put([FromBody] BeerDto beerDto)
        {
            _beerBussinessService.Update(beerDto);
        }

        // DELETE api/<BeerController>/5
        [HttpDelete("{identificationNumber}/{sourceId}")]
        public void Delete(Int64 identificationNumber, string sourceId)
        {
            _beerBussinessService.SoftDelete(sourceId, identificationNumber);
        }
    }
}
