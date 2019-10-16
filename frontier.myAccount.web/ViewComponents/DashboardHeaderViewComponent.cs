using frontier.myAccount.web.Services.Interfaces;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using frontier.myAccount.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace frontier.myAccount.web.ViewComponents
{
    public class DashboardHeaderViewComponent : ViewComponent
    {
        private readonly IUserService _userService;
        public DashboardHeaderViewComponent(IUserService userService)
        {
            this._userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_userService.GetLoggedInUser());
        }
    }
}
