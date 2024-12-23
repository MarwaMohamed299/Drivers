﻿using Drivers.DAL.Repositories.Trips;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Drivers.DAL.Repositories
{
    public class TripsRepository : ITripRepository
    {
        private readonly IMongoCollection<BsonDocument> _tripCollection;

        public TripsRepository(IMongoDatabase database)
        {
            _tripCollection = database.GetCollection<BsonDocument>("Trips");
        }

        public async Task<List<BsonDocument>> GetAverageTripDurationRawDataAsync()
        {
            var pipeline = new BsonDocument[]
            {
        // Unwind the Drivers array
        new BsonDocument("$unwind", "$Drivers"),

        // Convert the StartDate and EndDate to Date type and calculate duration
        new BsonDocument("$project", new BsonDocument
        {
            { "DriverId", "$Drivers" },
            {
                "Duration",
                new BsonDocument("$subtract", new BsonArray
                {
                    new BsonDocument("$toDate", "$EndDate"),
                    new BsonDocument("$toDate", "$StartDate")
                })
            }
        }),

        // Group by DriverId and calculate the average trip duration
        new BsonDocument("$group", new BsonDocument
        {
            { "_id", "$DriverId" },
            { "AverageTripDuration", new BsonDocument("$avg", "$Duration") }
        }),

        // Convert DriverId to ObjectId for the lookup (this is the change)
        new BsonDocument("$addFields", new BsonDocument
        {
            { "DriverObjectId", new BsonDocument("$toObjectId", "$_id") }
        }),
        // Project the final output structure
        new BsonDocument("$project", new BsonDocument
        {
            { "_id", 0 },
            { "DriverId", "$_id" },
            { "AverageTripDuration", 1 }
        })
            };

            // Execute the aggregation pipeline and return the results
            var rawData = await _tripCollection.Aggregate<BsonDocument>(pipeline).ToListAsync();

            return rawData;
        }

    }
}
