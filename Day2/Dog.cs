using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Dog : Animal
    {
        public Dog() : base(AnimalType.Dog)
        {
        }

        public override string AnimalNoise()
        {
            return "Woof";
        }
    }
}
