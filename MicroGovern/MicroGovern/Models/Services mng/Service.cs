using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MicroGovern.Models.Services_mng
{
    //code
    public class Service
    {
        [Key]
        public int ID { get; set; }
        public bool isleaf { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string icon { get; set; }
        public DateTime DateAdded { get; set; }

        private ICollection<Service> _subServices;
        public virtual ICollection<Service> subServices
        {
            get { return _subServices ?? (_subServices = new Collection<Service>()); }
            protected set { _subServices = value; }
        }

        public Service() {
            subServices = new List<Service>();
        }

        public bool add(Service newService) {
            subServices.Add(newService);
            return true;
        }
        public bool remove(Service nService)
        {
            subServices.Remove(nService);
            return true;
        }

        public List<Service> DisplayService()
        {
            return new List<Service>();
        }
    }

}