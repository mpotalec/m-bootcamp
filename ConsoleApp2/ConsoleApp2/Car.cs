using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Car : CarId //access modifiers(public,private,abstract itd)
    {
        public string type { get; set; } //encapsulation
        public string color { get; set; }
        public int year { get; set; }

        private string licensePlate = "a123";
        
        public void fullSpeed() { Console.WriteLine("This car is going full speed!"); }
    }
    
}
