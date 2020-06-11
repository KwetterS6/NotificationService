using System.Threading.Tasks;

namespace NotificationService.Services
{
    public interface INotificationService
    {
        Task sendRegisterMessage(string mail);
    }
}