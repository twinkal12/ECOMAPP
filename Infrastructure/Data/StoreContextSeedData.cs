using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeedData
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.productBrands.Any())
                {
                    var branddata = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brand = JsonSerializer.Deserialize<List<ProductBrand>>(branddata);
                    foreach (var item in brand)
                    {
                        context.productBrands.Add(item);

                    }
                    await context.SaveChangesAsync();
                }

                if (!context.productsType.Any())
                {
                    var typesdata = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var type = JsonSerializer.Deserialize<List<ProductType>>(typesdata);
                    foreach (var item in type)
                    {
                        context.productsType.Add(item);

                    }
                    await context.SaveChangesAsync();
                }
                 if (!context.products.Any())
                {
                    var productdata = File.ReadAllText("../Infrastructure/Data/SeedData/product.json");
                    var product = JsonSerializer.Deserialize<List<product>>(productdata);
                    foreach (var item in product)
                    {
                        context.products.Add(item);

                    }
                    await context.SaveChangesAsync();
                }


            }
            catch(Exception ex)
            {
                 var logger = loggerFactory.CreateLogger<StoreContextSeedData>();
                logger.LogError(ex.Message);

            }

        }
    }
}