using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MicroGovern.Models
{
    public class UserStats
    {
        [Key]
        public int ID { get; set; }
        public int servicesCompleted { get; set; }
        public int activeServices { get; set; }
        public double avgWorkingHrsPerWeek { get; set; }
        public double avgRatePerHr { get; set; }
        public double rating { get; set; }
        public double avgCompletionTime { get; set; }

        public UserStats()
        {
            servicesCompleted = 0;
            activeServices = 0;
            avgCompletionTime = 0;
            avgRatePerHr = 0.0;
            avgWorkingHrsPerWeek = 0.0;
            rating = 0.0;
        }
    }
}