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

            var extendedIndexKeyObject = new ExtendedIndexKeyClass
            {
                Age = 99,
                FirstName = "first",
                LastName = "last",
                NewIntger = 666
            };

            var stringKeyObject = new StringKeyClass
            {
                Age = 99,
                FirstName = "first",
                LastName = "last",
            };

            var indexKeyJson = SerializeAndDeserialize(indexKeyObject);
            Console.WriteLine($"{nameof(indexKeyJson)} : {indexKeyJson}");

            // Doesn't work for now
            //var stringKeyJson = SerializeAndDeserialize(stringKeyObject);
            //Console.WriteLine(stringKeyJson);

            var extendedIndexKeyJson = LZ4SerializeAndDeserialize(extendedIndexKeyObject);
            Console.WriteLine($"{nameof(extendedIndexKeyJson)} : {extendedIndexKeyJson}");

            SerializeAndDeserializeExtended();

            SerializeLZ4AndDeserializeExtended();

            SerializeExtendedLZ4AndDeserialize();

            //won't work
            //SerializeLZ4AndDeserializeDifferent();

            SerializeLZ4AndDeserializeDifferentWithSameKeys();
        }

        private static string SerializeAndDeserialize<T>(T input)
        {
            var bytes = MessagePackSerializer.Serialize(input);
            var deserialized = MessagePackSerializer.Deserialize<T>(bytes);

            var json = MessagePackSerializer.ConvertToJson(bytes);

            return json;
        }

        private static string LZ4SerializeAndDeserialize<T>(T input)
        {
            var lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4BlockArray);            

            var bytes = MessagePackSerializer.Serialize(input, lz4Options);
            var deserialized = MessagePackSerializer.Deserialize<T>(bytes, lz4Options);

            var json = MessagePackSerializer.ConvertToJson(bytes);

            return json;
        }        

        private static void SerializeAndDeserializeExtended()
        {
            var input = new IndexKeyClass
            {
                Age = 99,
                FirstName = "first",
                LastName = "last",
            };

            var bytes = MessagePackSerializer.Serialize(input);
            var deserialized = MessagePackSerializer.Deserialize<ExtendedIndexKeyClass>(bytes);
        }

        private static void SerializeLZ4AndDeserializeExtended()
        {
            var input = new IndexKeyClass
            {
                Age = 99,
                FirstName = "first",
                LastName = "last",
            };

            var lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4BlockArray);            

            var bytes = MessagePackSerializer.Serialize(input, lz4Options);
            var deserialized = MessagePackSerializer.Deserialize<ExtendedIndexKeyClass>(bytes, lz4Options);
        }

        private static void SerializeExtendedLZ4AndDeserialize()
        {
            var input = new ExtendedIndexKeyClass
            {
                Age = 99,
                FirstName = "first",
                LastName = "last",
                NewIntger = 1
            };

            var lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4BlockArray);            

            var bytes = MessagePackSerializer.Serialize(input, lz4Options);
            var deserialized = MessagePackSerializer.Deserialize<IndexKeyClass>(bytes, lz4Options);
        }

        private static void SerializeLZ4AndDeserializeDifferent()
        {
            var input = new ExtendedIndexKeyClass
            {
                Age = 99,
                FirstName = "first",
                LastName = "last",
                NewIntger = 1
            };

            var lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4BlockArray);            

            var bytes = MessagePackSerializer.Serialize(input, lz4Options);
            var deserialized = MessagePackSerializer.Deserialize<DifferentIndexKeyClass>(bytes, lz4Options);
        }

        private static void SerializeLZ4AndDeserializeDifferentWithSameKeys()
        {
            var input = new ExtendedIndexKeyClass
            {
                Age = 99,
                FirstName = "first",
                LastName = "last",
                NewIntger = 1
            };

            var lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4BlockArray);            

            var bytes = MessagePackSerializer.Serialize(input, lz4Options);
            var deserialized = MessagePackSerializer.Deserialize<SimilarIndexKeyClass>(bytes, lz4Options);
        }
    }
}
