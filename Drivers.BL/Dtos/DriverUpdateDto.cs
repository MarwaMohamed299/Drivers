using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.BL.Dtos
{
    public class DriverUpdateDto
    {
        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("Number")]
        public int Number { get; set; }
        public string Team { get; set; } = string.Empty;
    }
}
