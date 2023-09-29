using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class StockDto
    {
        [Required(ErrorMessage ="Beer Source Id is required")]
        public string BeerSourceId { get; set; }

        [Required(ErrorMessage = "Beer Amount is required")]
        public int Amount { get; set; }

        [Required(ErrorMessage ="WholeSaler SourceId is required")]
        public string WholeSalerSourceId { get; set; }
    }
}
