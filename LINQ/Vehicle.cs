using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Vehicle : IComparable<Vehicle>
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public int Weight { get; set; }
        public int GeneralId { get; set; }

        public int CompareTo(Vehicle other)
        {
            if (this.VehicleName.Length >= other.VehicleName.Length)
                return 1;

            return 0;
        }
    }
}
