using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using frontier.myAccount.web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace frontier.myAccount.web.ViewComponents
{
    public class ServiceAccountSelectorViewComponent : ViewComponent
    {
        private readonly IServiceAccountService _serviceAccountService;

        public ServiceAccountSelectorViewComponent(IServiceAccountService serviceAccountService)
        {
            this._serviceAccountService = serviceAccountService;
        }

        public IViewComponentResult Invoke(string customer_Id)
        {
            return View(_serviceAccountService.GetServiceAccountsByCustomerAccountId(customer_Id));
        }
    }
}
