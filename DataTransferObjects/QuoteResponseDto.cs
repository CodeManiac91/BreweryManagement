using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class QuoteResponseDto
    {
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceWithDiscount { get; set; }

        public decimal TotalAmmountOfBeers { get; set; }
        public string WholeSalerName { get; set; }
        public string WholeSalerSourceId { get; set; }

        public List<BeerQuoteDto> BeerList { get;set; }
    }
}
