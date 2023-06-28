using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Student
    {
        public Student()
        {
            Address = new List<Address>();
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }
        public bool IsEnrolled { get; set; }

        public List<Address> Address { get; set; }
    }
}
