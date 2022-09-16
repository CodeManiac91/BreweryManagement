using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class QuoteRequestDto
    {
        public string WholeSalerName { get; set; }
        public string WholeSalerSourceId { get; set; }
        public List<BeerQuoteDto> BeerList {get;set;}

    }

    public class BeerQuoteDto
    {
        public string SourceId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
