using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace HotelService.Messaging
{
    public class KafkaService: IKafkaService,IDisposable
    {
        private IProducer<string, string> _kafkaProducer;
        private IConsumer<string,string> _kafkaConsumer;
        private IHotelEventHandler _orderEventHandler;

        public KafkaService(IHotelEventHandler orderEventHandler)
        {
            _orderEventHandler = orderEventHandler;
            Initialize("localhost:9092");
            StartConsumeMessages();
        }
      
        private void Initialize(string uri)
        {
            IntitializeProducer(uri);
            IntitializeConsumer(uri);
        }

        private void IntitializeProducer(string uri)
        {
            var producerConfig = new ProducerConfig { BootstrapServers = uri };

            _kafkaProducer = new ProducerBuilder<string, string>(producerConfig).Build();
        }
        private void IntitializeConsumer(string uri)
        {
            var consumerConfig = new ConsumerConfig
            {
                GroupId = "hotel-consumer-group",
                BootstrapServers = uri,
                // Note: The AutoOffsetReset property determines the start offset in the event
                // there are not yet any committed offsets for the consumer group for the
                // topic/partitions of interest. By default, offsets are committed
                // automatically, so in this example, consumption will only start from the
                // earliest message in the topic 'my-topic' the first time you run the program.
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _kafkaConsumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
        }

        private async Task StartConsumeMessages()
        {
            _kafkaConsumer.Subscribe(KafkaConstants.Hotel_Topic);

            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) => {
                e.Cancel = true; // prevent the process from terminating.
                cts.Cancel();
            };

            try
            {
                while (true)
                {
                    try
                    {
                        var result = _kafkaConsumer.Consume(cts.Token);
                        _orderEventHandler.Handle(result.Key, result.Value);
                        Console.WriteLine($"Consumed message '{result.Value}' at: '{result.TopicPartitionOffset}'.");
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Error occured: {e.Error.Reason}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Ensure the consumer leaves the group cleanly and final offsets are committed.
                _kafkaConsumer.Close();
            }
        }
        public async Task SendEvent(string topic ,string eventName, string payload)
        {

            try
            {
                 _kafkaProducer.ProduceAsync(topic, new Message<string, string> {Key = eventName, Value = payload });
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }

        }


        public void Dispose()
        {
            _kafkaProducer?.Dispose();
            _kafkaConsumer?.Dispose();
        }
    }
}
