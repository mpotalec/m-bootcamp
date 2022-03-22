using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public abstract class CarId : ICarId
    {
       public string LicensePlate { get; set; }
    }
    
}
