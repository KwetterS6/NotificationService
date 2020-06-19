using NotificationService.Models;

namespace NotificationService.Helper
{
    public class EmailGenerator : IEmailGenerator
    {
        public Email CreateRegisterEmail() {
            var message = new Email
            {
                Title = "Welcome to Kwetter!",
                Content = 
                    "<h1><span>Welcome to Kwetter!</span></h1>\n<h2 style=\"color: #2e6c80;\"><span style=\"color: #000000;\">Please login to start kwetting!</span></h2>\n<p>&nbsp;</p>"
            };
            return message;
        }
    }
}