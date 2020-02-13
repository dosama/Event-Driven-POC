using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using HotelService.Data;
using HotelService.Repositories.MessageLogs;

namespace HotelService.Messaging
{
    public class KafkaService: IKafkaService,IDisposable
    {
        private IProducer<string, string> _kafkaProducer;
        private IConsumer<string,string> _kafkaConsumer;
        private IServiceProvider _serviceProvider;
        private IMessageLogsRepository _messageLogsRepository;
        public KafkaService(IServiceProvider serviceProvider, IMessageLogsRepository messageLogsRepository)
        {
            _serviceProvider = serviceProvider;
            _messageLogsRepository = messageLogsRepository;
            Initialize("localhost:9092");
            new Thread(() => StartConsumeMessages()).Start();
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
                GroupId = "test-consumer-group",
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
            var eventHandler = _serviceProvider.GetService(typeof(IHotelEventHandler)) as IHotelEventHandler;
            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) => {
                e.Cancel = true; // prevent the process from terminating.
                cts.Cancel();
            };

            var flag = true;
            try
            {
                while (true)
                {
                    try
                    {
                        if (flag)
                        {
                            List<TopicPartition> assignments = _kafkaConsumer.Assignment;
                            assignments.ForEach(topicPartition =>
                                _kafkaConsumer.Seek(new TopicPartitionOffset(topicPartition.Topic, topicPartition.Partition, new Offset(_messageLogsRepository.GetLastOffset()))));
                            flag = false;
                        }
                        var result = _kafkaConsumer.Consume(cts.Token);
                        eventHandler.Handle(result.Key, result.Value);

                        _messageLogsRepository.Log(new MessageLogs
                            {
                                CreatedDate = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")),
                                Message = "key: " + result.Key + "Value: " + result.Value,
                                Topic = KafkaConstants.Order_Topic,
                                Offset = result.TopicPartitionOffset.Offset.Value
                            }
                        );
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
