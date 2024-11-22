using DAL.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class AppContext : IdentityDbContext<ApplicationUser>
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }
    }
}
