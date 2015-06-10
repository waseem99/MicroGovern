using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Location
{
    public class location
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        public double longitude { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        public double latitude { get; set; }

    }
}