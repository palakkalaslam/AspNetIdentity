using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SendGrid;
using System.Net;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;

namespace UserIdentityModificationTest.Controllers
{
    public class EmailServiceController : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridasync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        private async Task configSendGridasync(IdentityMessage message)
        {
            var myMessage = new SendGridMessage();
            myMessage.AddTo(message.Destination);
            myMessage.From = new System.Net.Mail.MailAddress(
                                "shelter.developer@outlook.com");
            myMessage.Subject = message.Subject;
            myMessage.Text = message.Body;
            myMessage.Html = message.Body;
            //var username = "azure_2fc37521edfdbef72dc8da6a15a903c6@azure.com";
            //var pswd = "2QjShZ0hBJ8RB7P";
            var credentials = new NetworkCredential(
                       ConfigurationManager.AppSettings["azure_2fc37521edfdbef72dc8da6a15a903c6@azure.com"],
                       ConfigurationManager.AppSettings["2QjShZ0hBJ8RB7P"]
                       );

            // Create a Web transport for sending email.
            var transportWeb = new Web(credentials);

            // Send the email.
            if (transportWeb != null)
            {
                await transportWeb.DeliverAsync(myMessage);
            }
            else
            {
                Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }
        }
    }
}