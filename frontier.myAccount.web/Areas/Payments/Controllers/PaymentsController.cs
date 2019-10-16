using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace frontier.myAccount.web.Areas.Payments.Controllers
{
    [Area("Payments")]
    [Route("[area]/")]
    public class PaymentsController : Controller
    {
        public PaymentsController()
        {

        }

        [Route("View-My-Bill")]
        public IActionResult ViewMyBill()
        {
            ViewData["PaymentsView"] = "ViewMyBill";
            return View();
        }

        [Route("Make-Payment")]
        public IActionResult MakePayment()
        {
            ViewData["PaymentsView"] = "MakePayment";
            return View();
        }


        [Route("Payment-Accounts")]
        public IActionResult PaymentAccounts()
        {
            ViewData["PaymentsView"] = "PaymentAccounts";
            return View();
        }

        [Route("Payment-Options")]
        public IActionResult PaymentOptions()
        {
            ViewData["PaymentsView"] = "PaymentOptions";
            return View();
        }

        [Route("Payment-History/Bills")]
        public IActionResult PaymentHistory_Bills()
        {
            ViewData["PaymentsView"] = "Payment-History-Bills";
            return View();
        }

        [Route("Payment-History/Payments")]
        public IActionResult PaymentHistory_Payments()
        {
            ViewData["PaymentsView"] = "Payment-History-Payments";
            return View();
        }

        [Route("payment-history")]
        public IActionResult PaymentHistory()
        {
            ViewData["PaymentsView"] = "PaymentHistory";
            return View();
        }
    }
}