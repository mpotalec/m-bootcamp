using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Model : Car
    {
        public int horsePower { get; set; }
        public void honkSound()
        { Console.WriteLine("Hoot Hoot"); }
    }
}
