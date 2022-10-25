using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker.Generator;

namespace ExternalGenerators
{
    public class CharGenerator : IGenerator
    {
        public object Generate()
        {
            return Convert.ToChar(new Random().Next());
        }

        public Type GetGeneratorType()
        {
            return typeof(char);
        }
    }
}