using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Mouse : Animal
    {
        public Mouse() : base(AnimalType.Mouse)
        {
        }

        public override string AnimalNoise()
        {
            return "Squeak";
        }
    }
}
