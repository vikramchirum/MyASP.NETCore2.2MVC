using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace frontier.myAccount.web.Areas.Products.Controllers
{
    [AllowAnonymous]
    [Area("Products")]
    [Route("[area]/vikram")]
    public class HomeController : Controller
    {
        [Route("pig")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("About")]
        public IActionResult About()
        {
            return View();
        }
    }
}