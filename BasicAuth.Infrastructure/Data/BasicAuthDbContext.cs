using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAuth.Infrastructure.Data
{
    public class BasicAuthDbContext : IdentityDbContext
    {
        public BasicAuthDbContext(DbContextOptions<BasicAuthDbContext> options): base(options)
        {
                
        }
    }
}
