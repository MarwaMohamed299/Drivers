﻿using Drivers.BL.Dtos.Drivers;
using Drivers.BL.Dtos.Trips;
using Drivers.DAL.Repositories;
using Drivers.DAL.Repositories.Trips;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.BL.Services.Trips;

public class TripsService :ITripsService
{
    private readonly ITripRepository _tripRepository;

    public TripsService(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }
    public async Task<List<DriverAverageTripDurationDto>> GetAverageTripDurationForDriversAsync()
    {
        var rawData = await _tripRepository.GetAverageTripDurationRawDataAsync();

        return rawData.Select(doc => new DriverAverageTripDurationDto
        {
            DriverId = doc.GetValue("DriverId").AsString,
            AverageTripDuration = doc.GetValue("AverageTripDuration").ToDouble(),
            DriverReadDto = new DriverReadDto
            {
                Id = doc.GetValue("_id", BsonString.Empty).AsString,
                Name = doc.GetValue("Name", BsonString.Empty).AsString,
                Number = doc.GetValue("Number", new BsonInt32(0)).ToInt32(),
                Team = doc.GetValue("Team", BsonString.Empty).AsString
            }
        }).ToList();
        
    }

}