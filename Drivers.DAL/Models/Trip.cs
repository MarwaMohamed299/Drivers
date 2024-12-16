using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL.Models
{
    public class Trip
        {
            public string Id { get; set; } = string.Empty;
            public string Destination { get; set; } = null!;
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public List<Driver> Drivers { get; set; } = new List<Driver>();
    }

}
