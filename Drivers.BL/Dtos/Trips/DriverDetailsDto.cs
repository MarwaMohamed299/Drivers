using Drivers.DAL.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Drivers.BL.Dtos.Trips
{
    public class DriverDetailsDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Number { get; set; }
        public string Team { get; set; } = string.Empty;
    }
}