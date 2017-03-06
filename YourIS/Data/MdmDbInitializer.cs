using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourIS.Models.Mdm;

namespace YourIS.Data
{
    public static class MdmDbInitializer
    {

        public static async Task InitializeAsync(IServiceProvider serviceProvider, bool createUsers = true)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<MdmDbContext>();
                if (await db.Database.EnsureCreatedAsync())
                {
                    await InsertTestDataAsync(serviceProvider);
                    if (createUsers)
                    {
                        //  await CreateAdminUser(serviceProvider);
                    }
                }
            }
        }

        private async static Task InsertTestDataAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<MdmDbContext>();
                
                if (!db.Suppliers.Any())
                {
                    var suppliers = new Supplier[]
                    {
                        new Supplier{Name="Test", SupplierVersion = 0},
                    };

                    await AddOrUpdateAsync<Supplier>(serviceProvider, g => g.SupplierID, suppliers);
                }
            }
        }

        private static async Task AddOrUpdateAsync<TEntity>(
            IServiceProvider serviceProvider,
            Func<TEntity, object> propertyToMatch, IEnumerable<TEntity> entities)
            where TEntity : class
        {
            List<TEntity> existingData;

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<MdmDbContext>();
                existingData = db.Set<TEntity>().ToList();
            }

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())

            {
                var db = serviceScope.ServiceProvider.GetService<MdmDbContext>();
                foreach (var item in entities)
                {
                    db.Entry(item).State = existingData.Any(g => propertyToMatch(g).Equals(propertyToMatch(item)))
                        ? EntityState.Modified
                        : EntityState.Added;
                }
                await db.SaveChangesAsync();

            }

        }
    }

}
