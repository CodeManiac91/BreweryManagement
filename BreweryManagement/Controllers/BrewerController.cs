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
        private readonly IBrewerService _brewerService;

        public BrewerController(IBrewerService brewerService)
        {
            _brewerService = brewerService;
        }



        // GET: api/<BrewerController>
        [HttpGet]
        public IEnumerable<BrewerDto> Get()
        {
            return _brewerService.GetAllBrewers();
        }

        // GET api/<BrewerController>/5
        [HttpGet("{id}")]
        public BrewerDto Get(int id)
        {
            return _brewerService.GetBrewerById(id);
        }

        // POST api/<BrewerController>
        [HttpPost]
        public void Post([FromBody] BrewerDto brewerDto)
        {
            _brewerService.AddBrewer(brewerDto);
        }

        // PUT api/<BrewerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BrewerDto brewerDto)
        {
            _brewerService.Update(id,brewerDto);
        }

        // DELETE api/<BrewerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _brewerService.Delete(id);
        }
    }
}
