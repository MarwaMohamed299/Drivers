using Drivers.DAL.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.BL.Services
{
    public class DriverService
    {
        private readonly IMongoCollection<Driver> _driversCollection;
        public DriverService(IOptions<Shared.DataBaseSettings> databaseSettings)
        {

        }
    }
}
