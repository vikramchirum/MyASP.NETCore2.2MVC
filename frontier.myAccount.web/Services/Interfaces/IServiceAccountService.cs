using frontier.myAccount.web.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frontier.myAccount.web.Services.Interfaces
{
    public interface IServiceAccountService
    {
        List<ServiceAccountViewModel> GetServiceAccountsByCustomerAccountId(string customerAccountId);
    }
}
