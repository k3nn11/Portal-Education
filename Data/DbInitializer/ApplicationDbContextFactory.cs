using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DbInitializer
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<PortalContext>
    {
        public PortalContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PortalContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PL_Portal.Data;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new PortalContext(optionsBuilder.Options);

        }
    }
}
