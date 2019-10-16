using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using frontier.myAccount.web.Models;
using frontier.myAccount.web.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace frontier.myAccount.web.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public LoggedInUserViewModel GetLoggedInUser()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context != null
                && context.User != null
                && context.User.Identity != null)
            {
                var loggedInUser = new LoggedInUserViewModel();
                loggedInUser.UserName = context.User.Identity.Name;
                return loggedInUser;
            }

            return null;
        }
    }
}
