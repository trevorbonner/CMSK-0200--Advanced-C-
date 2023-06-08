using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public abstract class Animal
    {
        public Animal(AnimalType type)
        {
            AnimalType = type;
        }

        public AnimalType AnimalType { get; }
        protected string SecretProperty => "This is secret";
        public abstract string AnimalNoise();
    }

    public enum AnimalType
    {
        None,
        Bird,
        Cat,
        Dog,
        Mouse
    }
}
