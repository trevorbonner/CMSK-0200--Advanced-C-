using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class BaseChildTwo : BaseChildOne
    {
        public override string GetValue()
        {
            return "Child Two";
        }

        public override string SomeValue()
        {
            return base.SomeValue();
        }
    }
}
