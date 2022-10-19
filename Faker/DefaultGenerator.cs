using Faker.Generators;
using Faker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class DefaultGenerator
    {
        private Dictionary<Type, IGenerator> _generators = new Dictionary<Type, IGenerator>();

        public DefaultGenerator()
        {
            _generators.Add(typeof(int), new IntGenerator());
            _generators.Add(typeof(double), new DoubleGenerator());
            _generators.Add(typeof(DateTime), new DateGenerator());
        }

        private void SetGeneratorsFromPlugins()
        {
            string pathToAdvancedGeneratorsDll = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\lib\\");
            string[] allDll = Directory.GetFiles(pathToAdvancedGeneratorsDll, "*.dll");
            foreach (string dllPath in allDll)
            {
                Assembly asm = Assembly.LoadFrom(dllPath);
                foreach (Type type in asm.GetExportedTypes())
                {
                    Console.WriteLine(type);
                    if (type.IsClass && typeof(IGenerator).IsAssignableFrom(type))
                    {
                        IGenerator g = (IGenerator)Activator.CreateInstance(type);
                        _generators.Add(g.GetGeneratorType(), g);
                    }
                }
            }
        }

        public void AddGenerators(Dictionary<Type, IGenerator> generators)
        {
            foreach(var generator in generators)
            {
                if(!_generators.ContainsKey(generator.Key))
                    _generators.Add(generator.Key, generator.Value);
            }
        }

        public bool IsConsistGenerator(Type type)
        {
            return _generators.ContainsKey(type);
        }
        public object? Generate(Type type)
        {
            if (IsConsistGenerator(type))
                return _generators[type].Generate();
            else
                return null;
        }
    }
}
