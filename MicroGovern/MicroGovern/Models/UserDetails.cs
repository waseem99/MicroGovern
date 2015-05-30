using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroGovern.Models
{
    public class UserDetails
    {
        public int ID { get; set; }
        public String FullName { get; set; }
        public String AccountType { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime BirthDate { get; set; }
        public String PrimaryRole { get; set; }
        public String Country { get; set; }
        public String State { get; set; }
        public String City { get; set; }
        public String Address { get; set; }
        public String whoAmI { get; set; }
        public String profilePicURL { get; set; }

        public virtual ApplicationUser IUser { get; set; }
        public String ApplicationUserId { get; set; }
        public virtual UserStats stats { get; set; }
    }
}