using Drivers.BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.BL.Services.Drivers
{
    public interface IDriverService
    {
        Task<List<DriverReadDto>> GetAllDriversAsync();
        Task<DriverReadDto> GetDriverByIdAsync(string id);
        Task CreateDriverAsync(DriverAddDto driver);
        Task UpdateDriverAsync(string id, DriverUpdateDto driver);
        Task DeleteDriverAsync(string id);
    }
}
