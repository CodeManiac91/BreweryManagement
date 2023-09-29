using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class QuoteRequestDto
    {
        public string WholeSalerName { get; set; }

        [Required(ErrorMessage = "WholeSaler Source Id is required")]
        public string WholeSalerSourceId { get; set; }

        [Required(ErrorMessage ="Order list must be provided")]
        public List<BeerQuoteDto> BeerList {get;set;}

    }

    public class BeerQuoteDto
    {
        [Required(ErrorMessage = "Beer Source Id is required")]
        public string SourceId { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "Beer Ammount Id is required")]
        public int Amount { get; set; }
    }
}
