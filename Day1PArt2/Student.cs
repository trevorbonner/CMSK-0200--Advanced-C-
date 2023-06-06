using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1PArt2
{
    public class Student : Person
    {
        public override PersonType Type => PersonType.Student;
    }
}
