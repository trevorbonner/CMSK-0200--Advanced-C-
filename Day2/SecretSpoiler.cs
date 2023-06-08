using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class SecretSpoiler : Animal
    {
        public SecretSpoiler(AnimalType type) : base(type)
        {
        }

        public bool OnlyThisDoesIt()
        {
            return true;
        }

        public override string AnimalNoise()
        {
            return SecretProperty;
        }
    }
}
