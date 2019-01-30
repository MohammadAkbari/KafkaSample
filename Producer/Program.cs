using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new Dictionary<string, object>
            {
                { "bootstrap.servers", "192.168.20.82:9092" }
            };

            using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
            {
                var dr = producer.ProduceAsync("topic.xyz", null, "test message text").Result;
                Console.WriteLine($"Delivered '{dr.Value}' to: {dr.TopicPartitionOffset}");
            }
        }
    }
}