using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generator
{
    public class IntGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            return new Random().Next();
        }

        public Type GetGeneratorType()
        {
            return typeof(int);
        }
    }
}
