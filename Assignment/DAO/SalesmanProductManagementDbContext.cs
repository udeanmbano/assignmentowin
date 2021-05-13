using Microsoft.AspNet.Identity.EntityFramework;
using SalesmanProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SalesmanProductManagement.Models
{
    public class SalesmanProductManagementDbContext : IdentityDbContext<SalesmanUser>
    {
        public SalesmanProductManagementDbContext() : base("SalesmanProductManagementCS")
        {
            Configuration.ProxyCreationEnabled = false;
      

        }

        public DbSet<Tbl_Category> Categories { get; set; }
        public DbSet<Tbl_Product> Products { get; set; }
    }
}