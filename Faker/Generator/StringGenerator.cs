using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generator
{
    public class StringGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            var size = new Random().Next(1, 10);
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < size; i++)
                stringBuilder.Append((char)new Random().Next());

            return stringBuilder.ToString();
        }
        public Type GetGeneratorType()
        {
            return typeof(string);
        }
    }
}
