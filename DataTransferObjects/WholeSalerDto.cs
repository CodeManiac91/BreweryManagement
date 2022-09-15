using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class WholeSalerDto
    {
        [Required(ErrorMessage = "WholeSaler sourceId is required")]
        public string SourceId { get; set; }

        [Required(ErrorMessage = "WholeSaler name is required")]
        public string Name { get; set; }

        public bool Removed { get; set; }
    }
}
