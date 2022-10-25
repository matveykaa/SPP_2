using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker.Generator;

namespace Faker
{
    public class Faker
    {
        private Dictionary<string, IGenerator> _generators;
        private List<Type> _cycleDependClassHolder;
        private readonly FakerConfiguration _config;
    }
}
