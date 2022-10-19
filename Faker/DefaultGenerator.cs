using Faker.Generators;
using Faker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
