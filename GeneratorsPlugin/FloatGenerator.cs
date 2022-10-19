using Faker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorsPlugin
{
    public class FloatGenerator : IGenerator
    {
        public object Generate()
        {
            return new Random().NextSingle();
        }

        public Type GetGeneratedType()
        {
            return typeof(float);
        }
    }
}
