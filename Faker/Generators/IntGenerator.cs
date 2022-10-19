using Faker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generators
{
    public class IntGenerator : IGenerator
    {
        public object Generate()
        {
            return new Random().NextInt64() % 1000;
        }
    }
}
