using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtmLocator.Models
{
    public class Atm
    {
        public long ID { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string OpenHours { get; set; }
        public string Wheelchair { get; set; }
        public string Drive_Through { get; set; }
    }
}
