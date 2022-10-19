﻿using Faker.Interfaces;

namespace Faker.Generators
{
    public class BoolGenerator : IGenerator
    {
        public object Generate()
        {
            return true;
        }

        public Type GetGeneratedType()
        {
             return typeof(bool);   
        }
    }
}
