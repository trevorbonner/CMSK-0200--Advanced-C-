using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class ForGenerics
    {
        public static T ReturnGeneric<T>()
        {
            return default(T);
        }

        public static T1 ReturnGeneric<T1, T2>()
        {
            return default(T1);
        }
    }
}
