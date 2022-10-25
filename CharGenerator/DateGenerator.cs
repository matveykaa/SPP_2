using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;
using Faker.Generator;

namespace CharGenerator
{
    public class DateTimeGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            var year = new Random().Next(1, int.MaxValue);
            var month =new Random().Next(1, 12);
            var day = new Random().Next(1, DateTime.DaysInMonth(year, month));

            return new DateTime(year, month, day);
        }

        public Type GetGeneratorType()
        {
            return typeof(DateTime);
        }
    }
}
