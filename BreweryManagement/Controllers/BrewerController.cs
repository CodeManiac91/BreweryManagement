using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreweryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrewerController : ControllerBase
    {
        private readonly IBrewerBussinessService _brewerBussinessService;

        public BrewerController(IBrewerBussinessService brewerBussinessService)
        {
            _brewerBussinessService = brewerBussinessService;
        }



        // GET: api/<BrewerController>
        [HttpGet]
        public IEnumerable<BrewerDto> Get()
        {
            return _brewerBussinessService.GetAllBrewers();
        }

        // GET api/<BrewerController>/5
        [HttpGet("{identificationNumber}")]
        public BrewerDto Get(Int64 identificationNumber)
        {
            return _brewerBussinessService.GetBrewerByKey(x => x.IndentificationNumber == identificationNumber);
        }

        // POST api/<BrewerController>
        [HttpPost]
        public void Post([FromBody] BrewerDto brewerDto)
        {
            _brewerBussinessService.AddBrewer(brewerDto);
        }

        // PUT api/<BrewerController>/5
        [HttpPut]
        public void Put([FromBody] BrewerDto brewerDto)
        {
            _brewerBussinessService.Update(brewerDto);
        }

        // DELETE api/<BrewerController>/5
        [HttpDelete("{identificationNumber}")]
        public void Delete(Int64 identificationNumber)
        {
            _brewerBussinessService.SoftDelete(identificationNumber);
        }
    }
}
