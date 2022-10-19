using Faker.Interfaces;
public class IntGenerator: IGenerator
{
    public object Generate()
    {
        return new Random().Next() % 1000;
    }
}