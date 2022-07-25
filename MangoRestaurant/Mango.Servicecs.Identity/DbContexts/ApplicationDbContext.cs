using Mango.Servicecs.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mango.Servicecs.Identity.DbContexts
{
    public class ApplicationDbContexts : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContexts(DbContextOptions<ApplicationDbContexts> options) : base(options)
        {

        }       
    }
}
