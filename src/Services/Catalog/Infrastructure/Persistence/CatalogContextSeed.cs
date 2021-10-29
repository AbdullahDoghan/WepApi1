using Domain.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext catalogContext, ILogger<CatalogContextSeed> logger)
        {
            if (!catalogContext.Catalog.Any())
            {
                catalogContext.Catalog.AddRange(GetPreconfiguredCatalog());
                await catalogContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(CatalogContext).Name);
            }
        }

        private static IEnumerable<CatalogEntity> GetPreconfiguredCatalog()
        {
            return new List<CatalogEntity>
            {
                new CatalogEntity() {Name = "Iphone", Description = "nothing", LonDescription = "nothing nothing", Price = 700, Category = "Phone", Image ="Null" }
            };
        }
    }
}
