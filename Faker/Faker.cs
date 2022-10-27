using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Faker.Generator;

namespace Faker
{
    public class Faker : IFaker
    {
        private List<Type> createdUserTypes;
        private Dictionary<Type, IGenerator> valueGenerateDictionary = new Dictionary<Type, IGenerator>();
        public T Create<T>()
        {
            valueGenerateDictionary.Add(typeof(bool), new BoolGenerator());
            valueGenerateDictionary.Add(typeof(double), new DoubleGenerator());
            valueGenerateDictionary.Add(typeof(float), new FloatGenerator());
            valueGenerateDictionary.Add(typeof(int), new IntGenerator());
            valueGenerateDictionary.Add(typeof(long), new LongGenerator());
            valueGenerateDictionary.Add(typeof(Single), new SingleGenerator());
            valueGenerateDictionary.Add(typeof(string), new StringGenerator());
            AddPluginGenerators();
            createdUserTypes = new List<Type>();
            return (T)CreateDTO(typeof(T));
        }
        private object CreateDTO(Type type)
        {
            bool isSystem = false;
            if (hasGenerator(type))
            {
                isSystem = true;
                return Generate(type)!;
            }
            if (type.IsGenericType)
            {
                isSystem = true;
                var collection = (IList)Activator.CreateInstance(type);
                var collectionParametrizedType = type.GetGenericArguments()[0];
                collection.Add(CreateDTO(collectionParametrizedType));
                collection.Add(CreateDTO(collectionParametrizedType));
                return collection;
            }
            if (!createdUserTypes.Contains(type))
            {
                if (!isSystem)
                {
                    createdUserTypes.Add(type);
                }
                var createdObj = CreateObject(type);
                InitializePropsAndFields(createdObj);
                createdUserTypes.Remove(type);
                return createdObj;
            }
            throw new CyclicException();
        }

        private void InitializePropsAndFields(object obj)
        {
            var properties = obj.GetType().GetProperties();
            var fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            foreach (var field in fields)
            {
                var fd = CreateDTO(field.FieldType);
                field.SetValue(obj, fd);
            }
            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    var pr = CreateDTO(property.PropertyType);
                    property.SetValue(obj, pr);
                }
            }
        }
        private ConstructorInfo GetConstructor(Type type)
        {
            var constructors = type.GetConstructors();
            var constructor = constructors.OrderBy(c => c.GetParameters().Length).FirstOrDefault();
            return constructor;
        }
        private object CreateObject(Type type)
        {
            var constructor = GetConstructor(type);
            var constructorParametrs = constructor.GetParameters();
            var paramsList = new List<object>();
            foreach (var parameter in constructorParametrs)
            {
                paramsList.Add(CreateDTO(parameter.ParameterType));
            }
            return constructor.Invoke(paramsList.ToArray());
        }

        public bool hasGenerator(Type type)
        {
            return valueGenerateDictionary.ContainsKey(type);
        }
        public object Generate(Type type)
        {
            if (hasGenerator(type))
            {
                return valueGenerateDictionary[type].Generate();
            }
            return null;
        }

        private void AddPluginGenerators()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\");
            string[] dlls = Directory.GetFiles(path, "*.dll");
            foreach (string dll in dlls)
            {
                Assembly asm = Assembly.LoadFrom(dll);
                foreach (var type in asm.GetExportedTypes())
                {
                    if (type.IsClass && typeof(IGenerator).IsAssignableFrom(type))
                    {
                        IGenerator generator = (IGenerator)Activator.CreateInstance(type);
                        valueGenerateDictionary.Add(generator.GetGeneratorType(), generator);
                    }
                }
            }
        }
    }
}
