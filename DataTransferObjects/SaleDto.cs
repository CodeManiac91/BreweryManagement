using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class SaleDto
    {
        [Required]
        public string SalesOrderNumber { get; set; }

        [Required]
        public string BeerSourceId { get; set; }

        [Required]
        public string WholeSalerSourceId { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public Int64 BrewerIdentificationNumber { get; set; }

    }
}
