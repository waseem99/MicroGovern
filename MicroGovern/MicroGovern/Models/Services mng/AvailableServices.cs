using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Services_mng
{
    public class AvailableServices
    {
        [Key]
        public int ID { get; set; }
       
        public bool isleaf { get; set; }
        public List<AvailableServices> myServices { get; set; }
        public string Title { get; set; }
        public DateTime DateAdded { get; set; }
        public string Details { get; set; }

        public bool add(AvailableServices newService) {
            myServices.Add(newService);
            return true;
        }
        public bool remove(AvailableServices nService)
        {
            myServices.Remove(nService);
            return true;
        }
    }

}