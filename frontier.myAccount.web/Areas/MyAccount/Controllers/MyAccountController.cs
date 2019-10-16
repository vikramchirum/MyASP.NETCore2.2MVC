using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace frontier.myAccount.web.Areas.My_Account.Controllers
{
    [Area("MyAccount")]
    [Route("[area]/")]
    public class MyAccountController : Controller
    {
        public MyAccountController()
        {

        }

        [Route("Profile")]
        public IActionResult Index()
        {
            ViewData["MyAccountView"] = "Profile";
            return View();
        }

        [Route("Message-Center")]
        public IActionResult MessageCenter()
        {
            ViewData["MyAccountView"] = "Message-Center";
            return View();
        }

        [Route("Rewards-Referrals")]
        public IActionResult RewardsAndReferrals()
        {
            ViewData["MyAccountView"] = "Rewards-Referrals";
            return View();
        }
    }
}