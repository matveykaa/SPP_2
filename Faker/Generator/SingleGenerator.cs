using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generator
{
    public class SingleGenerator: IGenerator
    {
        public object Generate()
        {
            return (Single)new Random().NextDouble();
        }

        public Type GetGeneratorType()
        {
            return typeof(Single);
        }
    }
}
