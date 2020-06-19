using System;
using System.Text.Json;
using System.Threading.Tasks;
using MessageBroker;
using NotificationService.Messages;
using NotificationService.Services;

namespace NotificationService.MessageHandlers
{
    public class RegisterEmailHandler : IMessageHandler<RegisterMessage>
    {
        private readonly INotificationService _emailService;

        public RegisterEmailHandler(INotificationService emailService)
        {
            _emailService = emailService;
        }        
        
        public Task HandleMessageAsync(string messageType, RegisterMessage sendable)
        {
            Task.Run(() => { _emailService.sendRegisterMessage(sendable.Email); });
            
            return Task.CompletedTask;
        }

        public Task HandleMessageAsync(string messageType, byte[] obj)
        {
            return HandleMessageAsync(messageType, JsonSerializer.Deserialize<RegisterMessage>((ReadOnlySpan<byte>) obj, (JsonSerializerOptions) null));
        }
    }
}