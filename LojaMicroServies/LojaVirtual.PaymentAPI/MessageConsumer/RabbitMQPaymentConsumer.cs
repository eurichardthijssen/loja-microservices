﻿using LojaVirtual.PaymentAPI.Messages;
using LojaVirtual.PaymentAPI.RabbitMQSender;
using LojaVirtual.PaymentProcessos;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace LojaVirtual.PaymentAPI.MessageConsumer
{
    public class RabbitMQPaymentConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private IRabbitMQMessageSender _messageSender;
        private readonly IProcessPayment _processPayment;

        public RabbitMQPaymentConsumer(IProcessPayment processPayment, IRabbitMQMessageSender messageSender)
        {
            _processPayment = processPayment;
            _messageSender = messageSender;
            
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Password = "guest",
                UserName = "guest",
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "orderpaymentprocessqueue", false, false, false, arguments: null);

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                PaymentMessage vo = JsonSerializer.Deserialize<PaymentMessage>(content);
                ProcessPayment(vo).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag,false);
            };
            _channel.BasicConsume("orderpaymentprocessqueue", false,consumer);
            return Task.CompletedTask;
        }

        private async Task ProcessPayment(PaymentMessage vo)
        {
            var result =  _processPayment.PaymentProcessor();
            UpdatePaymentResultMessage paymentResult = new()
            {
                Status = result,
                OrderId = vo.OrderId,
                Email = vo.Email
            };

            try
            {
                //_messageSender.SendMessage(paymentResult, "orderpaymentresultqueue");
                _messageSender.SendMessage(paymentResult);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
