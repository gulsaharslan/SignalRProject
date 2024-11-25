using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalR.WebUI.Dtos.MailDtos;
using MailKit.Net.Smtp;

namespace SignalR.WebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Sakura Restoran Rezervasyon", "gulsah0502@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailDto.Body; ;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = createMailDto.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("gulsah0502@gmail.com", "epmj nufl niyd vvje");

            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("Index", "Statistic");
        }
    }
}
