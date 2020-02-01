using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KafkaNet;
using KafkaNet.Model;
using OrderServiceApi.Service;

namespace OrderServiceApi.Messaging
{
    public class KafkaService: IKafkaService
    {
        private Producer _kafkaProducer;
        private Consumer _kafkaConsumer;
        private IOrderEventHandler _orderEventHandler;
        private string[] _consumerTopics =
            {KafkaConstants.Hotel_Topic, KafkaConstants.Flight_Topic, KafkaConstants.Car_Topic};

        public KafkaService(IOrderEventHandler orderEventHandler)
        {
            _orderEventHandler = orderEventHandler;
            Configure("http://localhost:9092");
        }
        private void Configure(string uri)
        {
            var options = new KafkaOptions(new Uri(uri));
            var router = new BrokerRouter(options);
            Initialize(router);
        }

        private void Initialize(BrokerRouter router)
        {
            _kafkaProducer = new Producer(router);
            _kafkaConsumer = new Consumer(new ConsumerOptions(KafkaConstants.Order_Topic, router));
           
            foreach (var msg in _kafkaConsumer.Consume())
            {
                _orderEventHandler.Handle(Encoding.UTF8.GetString(msg.Key), Encoding.UTF8.GetString(msg.Value));
                Console.WriteLine(Encoding.UTF8.GetString(msg.Value));
            }
        }
        public async Task SendEvent(string topic ,string eventName, string payload)
        {
         
             KafkaNet.Protocol.Message msg = new KafkaNet.Protocol.Message(payload, eventName);
            _kafkaProducer.SendMessageAsync(topic, new List<KafkaNet.Protocol.Message> { msg });
           
        }

    
    }
}
