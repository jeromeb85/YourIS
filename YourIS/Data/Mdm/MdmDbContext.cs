using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourIS.Models.Mdm;

namespace YourIS.Data.Mdm
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

            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Mdm");
            
            var e = modelBuilder.Entity<Supplier>();
            e.HasKey(k => k.Id);
            e.Property(k => k.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            e.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
            e.Property(p => p.Timestamp)
            .ValueGeneratedOnAddOrUpdate()
            .IsConcurrencyToken();
        }
    }
}
