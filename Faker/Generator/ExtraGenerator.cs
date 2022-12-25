using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generator
{
    public class ExtraGenerator : IGenerator
    {
        public object Generate()
        {
            return 101;
        }

        public Type GetGeneratorType()
        {
            return typeof(string);
        }
    }
}
