using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using MessagePack;
using Newtonsoft.Json;
using ProtoBuf;

namespace serializationBenchmarks
{
    [SimpleJob(RunStrategy.Monitoring, targetCount: 100)]
    [MemoryDiagnoser, MinColumn, Q1Column, Q3Column, MaxColumn, MedianColumn]
    public class Benchmark
    {
        private List<RootObject> _program;

        [GlobalSetup]
        public void LoadDataset()
        {
            // string jsondata = File.ReadAllText("demo.json");
            string jsondata = File.ReadAllText("big_data.json");
            _program = JsonConvert.DeserializeObject<List<RootObject>>(jsondata);

        }

        [Benchmark]
        public void ToJson()
        {
            var json = JsonConvert.SerializeObject(_program);
            var result1 = JsonConvert.DeserializeObject(json);
        }

        [Benchmark]
        public void ToBtye()
        {
            byte[] byt;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, _program);
                byt = ms.ToArray();
            }

            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(byt, 0, byt.Length);
            memStream.Seek(0, SeekOrigin.Begin);


            var result2 = (List<RootObject>)binForm.Deserialize(memStream);
        }

        [Benchmark]
        public void ToMessagePack()
        {
            var msg = MessagePackSerializer.Serialize(_program);
            var result3 = MessagePackSerializer.Deserialize<List<RootObject>>(msg);
        }

        [Benchmark]
        public void ToProtobuf()
        {
            using (var file = File.Create("person.bin"))
            {
                Serializer.Serialize(file, _program);
            }

            RootObject newObject;
            using (var file = File.OpenRead("person.bin"))
            {
                newObject = Serializer.Deserialize<RootObject>(file);
            }
        }
    }
}