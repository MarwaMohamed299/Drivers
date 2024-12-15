using Drivers.BL.Dtos;
using Drivers.DAL.Models;
using Drivers.DAL.Repositories.Drivers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.BL.Services.Drivers
{
    public class DriverService :IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<List<DriverReadDto>> GetAllDriversAsync()
        {
            var drivers = await _driverRepository.GetAllDriversAsync();
            return drivers.Select(driver => new DriverReadDto
            {
                Id = driver.Id,
                Name = driver.Name,
                Number = driver.Number,
                Team = driver.Team
            }).ToList();
        }


        public async Task<DriverReadDto> GetDriverByIdAsync(string id)
        {
            var driver = await _driverRepository.GetDriverByIdAsync(id);
            return new DriverReadDto
            {
                Id = driver.Id,
                Name = driver.Name,
                Number = driver.Number,
                Team = driver.Team
            };
        }

        public async Task CreateDriverAsync(DriverAddDto driver)
        {
            var driverModel = new Driver
            {
                Name = driver.Name,
                Number = driver.Number,
                Team = driver.Team
            };

            await _driverRepository.CreateDriverAsync(driverModel);
        }

        public async Task UpdateDriverAsync(string id, DriverUpdateDto driver)
        {
            var driverModel = new Driver
            {
                Id = id,
                Name = driver.Name,
                Number = driver.Number,
                Team = driver.Team
            };

            await _driverRepository.UpdateDriverAsync(id, driverModel);
        }


        public async Task DeleteDriverAsync(string id)
        {
            await _driverRepository.DeleteDriverAsync(id);
        }
    }
}

