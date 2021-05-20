using CSharpPlayground.MessagePack.Model;
using MessagePack;
using System;

namespace CSharpPlayground.MessagePack
{
    class Program
    {
        static void Main(string[] args)
        {
            var indexKeyObject = new IndexKeyClass
            {
                Age = 99,
                FirstName = "first",
                LastName = "last",
            };

            var stringKeyObject = new StringKeyClass
            {
                Age = 99,
                FirstName = "first",
                LastName = "last",
            };

            var indexKeyJson = SerializeAndDeserialize(indexKeyObject);

            Console.WriteLine(indexKeyJson);

            // Doesn't work for now
            //var stringKeyJson = SerializeAndDeserialize(stringKeyObject);
            //Console.WriteLine(stringKeyJson);
        }

        private static string SerializeAndDeserialize<T>(T input)
        {
            var bytes = MessagePackSerializer.Serialize(input);
            var deserialized = MessagePackSerializer.Deserialize<T>(bytes);

            var json = MessagePackSerializer.ConvertToJson(bytes);

            return json;
        }
    }
}
