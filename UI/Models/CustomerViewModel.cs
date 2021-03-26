using Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class CustomerViewModel
    {
        public string Fullname { get; set; }
        public string HousePhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public List<CustomerType> CustomerType { get; set; }
    }
}
