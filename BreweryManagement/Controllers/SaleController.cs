using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Implementation;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreweryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleBussinessService _saleBussinessService;

        public SaleController(ISaleBussinessService saleBussinessService)
        {
            _saleBussinessService = saleBussinessService;
        }


        // GET: api/<SaleController>
        [HttpGet]
        public IEnumerable<SaleDto> Get()
        {
            return _saleBussinessService.GetAllSales();
        }

        // GET api/<SaleController>/5
        [HttpGet("{saleOrderNumber}")]
        public SaleDto Get(string saleOrderNumber)
        {
            return _saleBussinessService.GetSaleByKey(x => x.SalesOrderNumber == saleOrderNumber);
        }

        // POST api/<SaleController>
        [HttpPost]
        public void Post([FromBody] SaleDto saleDto)
        {
            _saleBussinessService.AddSale(saleDto);
        }

        // PUT api/<SaleController>/5
        [HttpPut]
        public void Put([FromBody] SaleDto saleDto)
        {
            _saleBussinessService.Update(saleDto);
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("{saleOrderNumber}")]
        public void Delete(string saleOrderNumber)
        {
            _saleBussinessService.HardDelete(saleOrderNumber);
        }
    }
}
