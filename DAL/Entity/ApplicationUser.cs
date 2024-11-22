using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public bool IsAgree { get; set; }
    }
}
