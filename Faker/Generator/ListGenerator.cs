using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generator
{
    public class ListGenerator<T> : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            var size = new Random().Next(1, 10);
            var list = (IList)Activator.CreateInstance(context.Type);

            for (int i = 0; i < size; i++)
            {
                list.Add(context.Faker.Create(context.Type.GetGenericArguments()[0]));
            }

            return list;
        }

        public Type GetGeneratorType()
        {
            return typeof(List<T>);
        }
    }
}
