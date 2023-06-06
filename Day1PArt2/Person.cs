using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1PArt2
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public virtual PersonType Type { get; }

        public override string ToString()
        {
            return $"First Name: {FirstName}, Last Name: {LastName}, Age: {Age}, Type: {Type}";
        }
    }

    public enum PersonType
    {
        Student,
        Teacher
    }
}
