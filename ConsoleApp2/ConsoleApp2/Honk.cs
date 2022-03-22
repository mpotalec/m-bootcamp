using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Honk : Model
    {
        public void honkSound()
        { Console.WriteLine("Honk Honk"); } //ovo bi trebao biti novi honkSound
                                            //naslijedio svojstva honkSound, ali promjenio(polymorphism)
                                            //override?
    }

    //class Animal  // Base class (parent) 
    //{
    //    public void animalSound()
    //    {
    //        Console.WriteLine("The animal makes a sound");
    //    }
    //}

    //class Pig : Animal  // Derived class (child) 
    //{
    //    public void animalSound()
    //    {
    //        Console.WriteLine("The pig says: wee wee");
    //    }
    //}

    //class Animal  // Base class (parent) 
    //{
    //    public virtual void animalSound()
    //    {
    //        Console.WriteLine("The animal makes a sound");
    //    }
    //}

    //class Pig : Animal  // Derived class (child) 
    //{
    //    public OVERRIDE void animalSound()
    //    {
    //        Console.WriteLine("The pig says: wee wee");
    //    }
    //}
}
