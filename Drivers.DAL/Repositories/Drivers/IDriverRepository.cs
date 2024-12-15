using Drivers.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL.Repositories.Drivers
{
    public interface IDriverRepository
    {
        Task<List<Driver>> GetAllDriversAsync();
        Task<Driver> GetDriverByIdAsync(string id);
        Task CreateDriverAsync(Driver driver);
        Task UpdateDriverAsync(string id, Driver driver);
        Task DeleteDriverAsync(string id);
    }
}
