using Amazon.SQS;
using Amazon.Runtime;
using Amazon.SQS.Model;
using System.Text.Json;
using System;
using RpgApplication.Models;
using RpgApplication.Interfaces;

namespace RpgApplication.Adapter
{
    public class SqsConsumer : BackgroundService
    {
        private static readonly string SecretKey = "ignore";
        private static readonly string AccessKey = "ignore";
        private static readonly string ServiceUrl = "http://localhost.localstack.cloud:4566";
        private static readonly string QueueUrl = "http://sqs.sa-east-1.localhost.localstack.cloud:4566/000000000000/teste";
        private static readonly string QueuePersonagemUrl = "http://sqs.sa-east-1.localhost.localstack.cloud:4566/000000000000/personagem";

        private readonly IRPGService _rpgService;

        public SqsConsumer(IRPGService rpgService)
        {
            _rpgService = rpgService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var awsCreds = new BasicAWSCredentials(AccessKey, SecretKey);
            var config = new AmazonSQSConfig
            {
                ServiceURL = ServiceUrl,
                //RegionEndpoint = RegionEndpoint.SAEast1
            };
            var amazonSqsClient = new AmazonSQSClient(config);

            while (!stoppingToken.IsCancellationRequested)
            {
                var request = new ReceiveMessageRequest()
                {
                    QueueUrl = QueuePersonagemUrl,
                };
                var response = await amazonSqsClient.ReceiveMessageAsync(request);

                foreach (var message in response.Messages)
                {
                    if (ProcessMessage(message))
                    {
                        await DeleteMessage(amazonSqsClient, message, request.QueueUrl);
                    }

                }
            }
        }

        //
        // Method to process a message
        // In this example, it simply prints the message
        private bool ProcessMessage(Message message)
        {
            Person person = null;
            try
            {
                var options = new JsonSerializerOptions()
                {
                    IncludeFields = true,
                };

                if (message.Body != null)
                {
                    person = JsonSerializer.Deserialize<Person>(message.Body, options);
                    if (person is null) return false;
                    _rpgService.savePersonagem(person);
                    Console.WriteLine(person is not null ? person.Name : "");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }

        private static async Task DeleteMessage(
          IAmazonSQS sqsClient, Message message, string qUrl)
        {
            Console.WriteLine($"\nDeleting message {message.MessageId} from queue...");

            await sqsClient.DeleteMessageAsync(qUrl, message.ReceiptHandle);
        }

    }
}
