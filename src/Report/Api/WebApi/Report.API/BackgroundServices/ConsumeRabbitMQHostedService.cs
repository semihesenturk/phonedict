using Microsoft.Net.Http.Headers;
using PhoneDict.Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Report.API.BackgroundServices
{
    public class ConsumeRabbitMQHostedService : BackgroundService
    {
        #region Variables
        private IConnection _connection;
        private IModel _channel;
        private readonly IHttpClientFactory _httpClientFactory;
        #endregion

        #region Constructor
        public ConsumeRabbitMQHostedService(IHttpClientFactory httpClientFactory)
        {
            InitRabbitMQ();
            _httpClientFactory = httpClientFactory;
        }
        #endregion

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                // received message  
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                HandleMessage(message);

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerConsumerCancelled;

            _channel.BasicConsume(PhoneDictConstants.CreateReportQueueName, false, consumer);
            return Task.CompletedTask;
        }

        private void InitRabbitMQ()
        {
            var factory = new ConnectionFactory { HostName = PhoneDictConstants.RabbitMQHost };

            // create connection  
            _connection = factory.CreateConnection();

            // create channel  
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(PhoneDictConstants.CreateReportQueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }
        private async void HandleMessage(string content)
        {
            var httpClient = _httpClientFactory.CreateClient("Report");
            var httpResponseMessage = await httpClient.GetAsync(
                "https://localhost:7141/api/Contacts/GetContactsByLocation");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();
            }
        }

        private void OnConsumerConsumerCancelled(object sender, ConsumerEventArgs e) { }
        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e) { }
        private void OnConsumerRegistered(object sender, ConsumerEventArgs e) { }
        private void OnConsumerShutdown(object sender, ShutdownEventArgs e) { }
        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e) { }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
