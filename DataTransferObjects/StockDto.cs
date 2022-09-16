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
        [Required]
        public string BeerSourceId { get; set; }

        [Required]
        public int Amount;

        [Required]
        public string WholeSalerSourceId { get; set; }
    }
}
