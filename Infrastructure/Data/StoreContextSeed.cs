using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var BrandsData=File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
                    foreach( var Item in brands)
                    {
                        context.ProductBrands.Add(Item);
                    }
                    await context.SaveChangesAsync();
                }
                 if (!context.ProductTypes.Any())
                {
                    var TypesData=File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
                    foreach( var Item in Types)
                    {
                        context.ProductTypes.Add(Item);
                    }
                    await context.SaveChangesAsync();
                }
                 if (!context.Products.Any())
                {
                    var ProductsData=File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                    foreach( var Item in products)
                    {
                        context.Products.Add(Item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger=loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);

            }
            
        }
    }
}