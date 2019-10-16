using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frontier.myAccount.web.Models
{
    public class ServiceAccountViewModel
    {
        public string Id { get; set; }

        public string Status { get; set; }

        public AddressViewModel Address { get; set; }

        public string DisplayValue
        {
            get
            {
                if (Address != null)
                {
                    var display = string.Join(string.Empty, this.Address.Line_1
                                      , !string.IsNullOrWhiteSpace(this.Address.Line_2) ? " " + this.Address.Line_2 : string.Empty
                                      , ", "
                                      , this.Address.City
                                      , ", "
                                      , this.Address.State
                                      , " ", this.Address.Zip
                                      , !string.IsNullOrWhiteSpace(this.Address.Zip_4) ? "-" + this.Address.Zip_4 : string.Empty);

                    if (this.Status == "Disconnected")
                    {

                        display += " " + "(Closed Acount)";
                    }

                    return display;
                }

                return null;
            }
        }
    }
}
