using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generator
{
    public class IntGenerator : IGenerator
    {
        public object Generate()
        {
            return new Random().Next();
        }

        public Type GetGeneratorType()
        {
            return typeof(int);
        }
    }
}
