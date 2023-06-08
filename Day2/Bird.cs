using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Bird : Animal
    {
        public Bird() : base(AnimalType.Bird)
        {
        }

        public override string AnimalNoise()
        {
            return "Chirp";
        }
    }
}
