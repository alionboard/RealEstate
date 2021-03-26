using Data.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Concrete
{
    public class Customer : IEntity
    {
        public Customer()
        {
            CustomerTypes = new HashSet<CustomerTypeCustomer>();
        }
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string HousePhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public virtual ICollection<CustomerTypeCustomer> CustomerTypes { get; set; }
        public virtual ICollection<Estate> Estates { get; set; }
    }

}