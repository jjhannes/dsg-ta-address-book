using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.WebApi.Settings
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int TokenTTL { get; set; }
    }
}
