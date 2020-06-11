using NotificationService.Models;

namespace NotificationService.Helper
{
    public interface IEmailGenerator
    {
        /// <summary>
        /// Creates an email object for the register action
        /// </summary>
        /// <returns>Email object with a body and subject</returns>
        Email CreateRegisterEmail();
    }
}