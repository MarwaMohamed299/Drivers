using Drivers.BL.Dtos.Drivers;
using Drivers.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.BL.Dtos.Trips
{
    public class DriverAverageTripDurationDto
    {
        public required string DriverId { get; set; }
        public double AverageTripDuration { get; set; }
    }
}
