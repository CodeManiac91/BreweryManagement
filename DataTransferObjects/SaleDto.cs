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
        [Required(ErrorMessage = "Sale Order Number is required")]
        public string SalesOrderNumber { get; set; }

        [Required(ErrorMessage = "Beer SourceId Number is required")]
        public string BeerSourceId { get; set; }

        [Required(ErrorMessage = "WholeSaler source id is required")]
        public string WholeSalerSourceId { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public int Amount { get; set; }

        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Brewer Identification Number is required")]
        public Int64 BrewerIdentificationNumber { get; set; }

    }
}
