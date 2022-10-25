using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Faker.Generator;

namespace Faker
{
    public class PluginLoader
    {
        private readonly string _pluginsPath;

        private Dictionary<string, IGenerator> Generators { get; set; }

        public PluginLoader(string pluginsPath)
        {
            _pluginsPath = pluginsPath;
        }

        public Dictionary<string, IGenerator> LoadPlugins(Faker faker)
        {
            Generators ??= new Dictionary<string, IGenerator>();

            Generators.Clear();

            var pluginsPaths = Directory.GetFiles(_pluginsPath, "*.dll");

            foreach (var pluginsPath in pluginsPaths)
            {
                var asm = Assembly.LoadFrom(pluginsPath);

                var types = asm.GetTypes().Where(t => t.
                    GetInterfaces().Any(i => i.FullName == typeof(IGenerator).FullName));

                foreach (var type in types)
                {
                    try
                    {
                        var plugin = (IGenerator)Activator.CreateInstance(type);
                        Generators.Add(plugin.GetType().ToString(), plugin);
                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            return Generators;
        }
    }
}
