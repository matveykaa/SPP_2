using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class Comparer : IComparer<ConstructorInfo>
    {
        public int Compare(ConstructorInfo x, ConstructorInfo y)
        {
            int xParamCount = x.GetParameters().Length;
            int yParamCount = y.GetParameters().Length;

            if (xParamCount == yParamCount) 
                return 0;
            if (xParamCount > yParamCount)
                return -1;
            else
                return 1;
        }
    }
}
