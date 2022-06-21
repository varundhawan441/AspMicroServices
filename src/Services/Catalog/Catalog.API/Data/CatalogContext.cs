using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<String>("DatabaseSetting:DatabaseConnection"));
            var database = client.GetDatabase(configuration.GetValue<String>("DatabaseSetting:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<String>("DatabaseSetting:DatabaseCollectionName"));
            // Run when application startup check any data exist in product collection or not
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
