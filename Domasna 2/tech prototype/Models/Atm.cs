using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AtmLocator.Models
{
    public class Atm
    {
        public int ID { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string OpenHours { get; set; }
        public Boolean Wheelchair { get; set; }
        public Boolean Drive_Through { get; set; }

    }
}