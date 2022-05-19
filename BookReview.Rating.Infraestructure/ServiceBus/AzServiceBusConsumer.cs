using Azure.Messaging.ServiceBus;
using BookReview.Rating.Application.Contracts.Bus;
using BookReview.Rating.Domain.Messages;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookReview.Rating.Infraestructure.ServiceBus
{
    public class AzServiceBusConsumer : BackgroundService
    {
        private readonly ILogger<AzServiceBusConsumer> _logger;
        private readonly ServiceBusClient _client;
        private readonly ServiceBusProcessor _processor;

        public AzServiceBusConsumer(ILogger<AzServiceBusConsumer> logger)
        {
            _logger = logger;
            _client = new ServiceBusClient(EnvVariables.SERVICE_BUS_STRING);
            _processor = _client.CreateProcessor(EnvVariables.TOPIC_BUS, EnvVariables.SUBSCRIPTION_NAME);

            _processor.ProcessMessageAsync += ProcessorMessageAsync;
            _processor.ProcessErrorAsync += ProcessorErrorAsync;
        }

        private Task ProcessorErrorAsync(ProcessErrorEventArgs arg)
        {
            _logger?.LogError(arg.Exception.ToString());
            return Task.CompletedTask;
        }

        private async Task ProcessorMessageAsync(ProcessMessageEventArgs args)
        {
            var message = args.Message.Body.ToString();
            var _event = JsonConvert.DeserializeObject<BookRatingMessage>(message);
            await args.CompleteMessageAsync(args.Message);
            _logger?.LogInformation(message); 
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _processor.StartProcessingAsync(stoppingToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await _processor.StartProcessingAsync(cancellationToken);
        }
    }
}
