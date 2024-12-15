using Drivers.DAL.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL.Repositories.Drivers
{
    public class DriverRepository : IDriverRepository
    {
        private readonly IMongoCollection<Driver> _driversCollection;

        public DriverRepository(IOptions<Shared.DataBaseSettings> databaseSettings)
        {
            //initialize mongo client

            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            // Connect to MongoDB database

            var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DataBaseName);

            // connect to Drivers Collection

            _driversCollection = mongoDb.GetCollection<Driver>(databaseSettings.Value.CollectionName);
        }

        public async Task<List<Driver>> GetAllDriversAsync()
        {
            return await _driversCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Driver> GetDriverByIdAsync(string id)
        {
            return await _driversCollection.Find(d => d.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateDriverAsync(Driver driver)
        {
            await _driversCollection.InsertOneAsync(driver);
        }

        public async Task UpdateDriverAsync(string id, Driver driver)
        {
            await _driversCollection.ReplaceOneAsync(d => d.Id == id, driver);
        }

        public async Task DeleteDriverAsync(string id)
        {
            await _driversCollection.DeleteOneAsync(d => d.Id == id);
        }
    }
}
