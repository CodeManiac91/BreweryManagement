using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Implementation;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreweryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockBussinessService _stockBussinessService;

        public StockController(IStockBussinessService stockBussinessService) {
            _stockBussinessService = stockBussinessService;
        }


        // GET: api/<StockController>
        [HttpGet]
        public IEnumerable<StockDto> Get()
        {
            return _stockBussinessService.GetAllStocks();
        }

        // GET api/<StockController>/5
        [HttpGet("{wholeSalerSourceId}")]
        public StockDto Get(string wholeSalerSourceId)
        {
            return _stockBussinessService.GetStockByKey(x => x.WholeSaler.SourceId == wholeSalerSourceId);
        }

        // POST api/<StockController>
        [HttpPost]
        public void Post([FromBody] StockDto stockDto)
        {
            _stockBussinessService.AddStock(stockDto);
        }

        // PUT api/<StockController>/5
        [HttpPut]
        public void Put([FromBody] StockDto stockDto)
        {
            _stockBussinessService.Update(stockDto);
        }

        // DELETE api/<StockController>/5
        [HttpDelete("{beerSourceId}/{wholeSalerSourceId}")]
        public void Delete(string beerSourceId, string wholeSalerSourceId)
        {
            _stockBussinessService.HardDelete(beerSourceId, wholeSalerSourceId);
        }
    }
}
