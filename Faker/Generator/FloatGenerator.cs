using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generator
{
    public class FloatGenerator : IGenerator
    {
        public object Generate()
        {
            double mantissa = (new Random().NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, new Random().Next(-126, 128));

            return (float)(mantissa * exponent + float.MinValue);
        }

        public Type GetGeneratorType()
        {
            return typeof(float);
        }
    }
}
