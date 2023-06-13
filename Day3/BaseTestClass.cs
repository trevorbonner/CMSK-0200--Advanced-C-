using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public abstract class BaseTestClass
    {
        public abstract string GetValue();

        public virtual string SomeValue()
        {
            return "Base";
        }
    }
}
