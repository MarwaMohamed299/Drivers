using Drivers.BL.Dtos.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.BL.Services.Trips
{
    public interface ITripsService
    {
        Task<List<DriverAverageTripDurationDto>> GetAverageTripDurationForDriversAsync();
    }
}
