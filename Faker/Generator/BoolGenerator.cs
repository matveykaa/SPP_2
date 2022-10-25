using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generator
{
    public class BoolGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            return Convert.ToBoolean(new Random().Next(0, 1));
        }

        public Type GetGeneratorType()
        {
            return typeof(bool);
        }
    }
}
