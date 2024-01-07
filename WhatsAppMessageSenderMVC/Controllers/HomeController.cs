using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WhatsApp.API;
using WhatsAppMessageSenderMVC.Models;

namespace WhatsAppMessageSenderMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult WhatsAppNotifier()
        {
            return View();
        }

        public IActionResult MessageSent()
        {
            return View();
        }

        public IActionResult SendWhatsAppNotification(WhatsAppNotifierPayLoad payLoad)
        {
            payLoad.AccountSid = "ACb8a3ffdd5972f27c8b9c9c0483918fa3";
            payLoad.AuthToken = "9ca33aa943b1d37fadb7fc056eb83d5d";

            payLoad.FromNumber = "+14155238886";
            var waClient = new WhatsAppAPI();
            waClient.SendNotification(payLoad);
            return RedirectToAction("MessageSent");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
