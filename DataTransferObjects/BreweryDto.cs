﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class BreweryDto
    {
        [Required(ErrorMessage = "Brewery name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Brewery sourceId is required")]
        public string SourceId { get; set; }
        [Required(ErrorMessage = "Brewer identification number is required")]
        public Int64 BrewerIdentificationNumber { get; set; }
        public bool Removed { get; set; }
    }
}