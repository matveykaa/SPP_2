using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generator
{
    public class LongGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            return new Random().NextInt64();
        }
        public Type GetGeneratorType()
        {
            return typeof(long);
        }
    }
}
