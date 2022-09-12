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
        [Required]
        public string Name { get; set; }
    }
}
