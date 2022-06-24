using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class VehicleComparer : IEqualityComparer<Vehicle>
    {
        public bool Equals(Vehicle x, Vehicle y)
        {
            if (x.VehicleId == y.VehicleId && x.VehicleName.ToLower() == y.VehicleName.ToLower())
                return true;
            else
                return false;
        }

        public int GetHashCode(Vehicle obj)
        {
            return obj.GetHashCode();
        }
    }
}
