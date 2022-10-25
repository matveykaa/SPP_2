using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generator
{
    public class DoubleGenerator: IGenerator
    { 
        public object Generate(GeneratorContext context)
        {
            return new Random().NextDouble();
        }

        public Type GetGeneratorType()
        {
            return typeof(double);
        }
    }
}
