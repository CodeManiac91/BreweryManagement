using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class BrewerDto
    {
        [Required(ErrorMessage = "Brewer name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Brewer indentification number is required")]
        public Int64 IdentificationNumber { get; set; }

        public bool Removed { get; set; }
    }
}
