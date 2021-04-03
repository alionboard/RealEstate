using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class AddCustomerDto
    {
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string HousePhoneNumber { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public List<int> CustomerTypes { get; set; }

    }
}
