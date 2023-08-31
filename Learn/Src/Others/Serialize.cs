using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Learn.Others
{
    [Serializable]
    public class SomeData
    {
        [NonSerialized]
        protected string mName = "private";
        public string Name = "";
        public int Age { get; set; }
        [NonSerialized]
        public string Info = "";

        public override string ToString()
        {
            return $"Name: {Name},Age: {Age},Info: {Info},PrivateName:{mName}";
        }

    }

    class XmlFormatter: System.Runtime.Serialization.IFormatter
    {
        protected XmlSerializer serialize = new XmlSerializer(typeof(List<SomeData>));
        public object Deserialize(Stream serializationStream)
        {
            return this.serialize.Deserialize(serializationStream);
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            this.serialize.Serialize(serializationStream, graph);
        }

        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }
        public ISurrogateSelector SurrogateSelector { get; set; }
    }

    public class SerializeTest
    {

        [Test]
        public void SerializeTestList()
        {
            this.Serialize<BinaryFormatter>("binSerialize.txt");
            this.Serialize<XmlFormatter>("xmlSerialize.txt");
        }

        protected void Serialize<T>(string file) where T: System.Runtime.Serialization.IFormatter, new()
        {
            var rootDir = AppDomain.CurrentDomain.BaseDirectory;
            var fileName = Path.Combine(rootDir, file);
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            {
                var list = new List<SomeData>();
                list.Add(new SomeData()
                {
                    Name = "a1",
                    Age = 1,
                    Info = "info1"
                });
                list.Add(new SomeData()
                {
                    Name = "a2",
                    Age = 2,
                    Info = "info1"
                });
                var formatter = new T();
                // var binFormat = new BinaryFormatter();
                formatter.Serialize(fStream, list);

            }
            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                // 重制流位置
                fStream.Position = 0;
                // var binFormat = new BinaryFormatter();
                var formatter = new T();
                List<SomeData> list = (List<SomeData>)formatter.Deserialize(fStream);
                foreach (var item in list)
                {
                    Console.WriteLine($"{file}>>>>>>> " + item.ToString());
                }
            }
        }

    }
}