using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourIS.Models.Mdm;

namespace YourIS.Data
{
    public class MdmDbContext : DbContext
    {
        public MdmDbContext(DbContextOptions<MdmDbContext> options)
            : base(options)
        {
           
        }

        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
        }
    }
}
