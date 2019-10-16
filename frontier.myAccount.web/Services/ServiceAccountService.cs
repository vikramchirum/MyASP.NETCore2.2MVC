using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using frontier.myAccount.web.Models;
using frontier.myAccount.web.Services.Interfaces;

namespace frontier.myAccount.web.Services
{
    public class ServiceAccountService : IServiceAccountService
    {
        public List<ServiceAccountViewModel> GetServiceAccountsByCustomerAccountId(string customerAccountId)
        {
            var list = new List<ServiceAccountViewModel> {

                new ServiceAccountViewModel { Id = "4542454" , Address = new AddressViewModel { Line_1 = "3405 N SHEPHERD DR", Line_2 = "#609", City= "Houston", State = "TX", Zip = "77018" }  },
                new ServiceAccountViewModel { Id = "4542454" , Address = new AddressViewModel { Line_1 = "3405 N SHEPHERD DR", Line_2 = "#609", City= "Houston", State = "TX", Zip = "77018" }  }
            };

            return list;
        }
    }
}
