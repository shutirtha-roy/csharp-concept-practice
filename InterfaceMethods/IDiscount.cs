using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMethods
{
    public interface IDiscount
    {
        double CalculateAmount(double originalAmount);
        public double GetAmount()
        {
            return 0;
        }
    }
}
