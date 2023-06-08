using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Cat : Animal
    {
        public Cat() : base(AnimalType.Cat)
        {
        }

        public override string AnimalNoise()
        {
            return "Meow";
        }
    }
}
