using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generator
{
    public class QueueGenerator<T> : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            var size = new Random().Next(1, 10);
            var stack = (Queue)Activator.CreateInstance(context.Type);

            for (int i = 0; i < size; i++)
            {
                stack.Enqueue(context.Faker.Create(context.Type.GetGenericArguments()[0]));
            }

            return stack;
        }

        public Type GetGeneratorType()
        {
            return typeof(Queue<T>);
        }
    }
}
