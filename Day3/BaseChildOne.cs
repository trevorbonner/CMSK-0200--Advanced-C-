using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class BaseChildOne : BaseTestClass
    {
        public override string GetValue()
        {
            return "Child One";
        }

        public override string SomeValue()
        {
            return base.SomeValue();
        }
    }
}
