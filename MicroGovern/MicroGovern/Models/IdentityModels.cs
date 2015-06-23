using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using System;

namespace MicroGovern.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public String AccountStatus {get; set;}
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {

            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<UserDetails> usersdb { get; set; }
        //public System.Data.Entity.DbSet<UserStats> usersStatsdb { get; set; }
        public System.Data.Entity.DbSet<MicroGovern.Models.Services_mng.Service> Services { get; set; }

        public System.Data.Entity.DbSet<MicroGovern.Models.Request_mng.Request> Requests { get; set; }

        public System.Data.Entity.DbSet<MicroGovern.Models.Responses_mng.Response> Responses { get; set; }

        public System.Data.Entity.DbSet<MicroGovern.Models.Location.location> Location { get; set; }
        public System.Data.Entity.DbSet<MicroGovern.Models.Request_mng.ARequestState> ARequestStates { get; set; }

        public System.Data.Entity.DbSet<MicroGovern.Models.Responses_mng.ResponseADecorater> ResponseADecoraters { get; set; }
    }
}