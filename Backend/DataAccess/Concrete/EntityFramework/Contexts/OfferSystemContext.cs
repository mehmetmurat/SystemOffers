using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class OfferSystemContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=78.142.210.2\MSSQLSERVER2012;Database=OfferSystem;User Id=offer82;Password=Fi8z*d60;");
        }
        public DbSet<Users> Schools { get; set; }
    }
}
