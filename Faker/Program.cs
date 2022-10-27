using System;
using System.Collections;
using System.Collections.Generic;
using Faker.Generator;
using Faker.DTO;
using System.Text.Json;

namespace Faker
{
    internal static class Program
    {
        private static void Main(string[] args)
        {

            IFaker faker = new Faker();
            var pic = faker.Create<Picture>();
            var result = JsonSerializer.Serialize(pic, new JsonSerializerOptions() { WriteIndented = true });
            Console.WriteLine(result);

        }
    }
}