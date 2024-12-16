using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL.Repositories.Trips
{
    public interface ITripRepository
    {
        Task<List<BsonDocument>> GetAverageTripDurationRawDataAsync();
    }
}
