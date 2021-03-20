using Data.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string HousePhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public virtual IEnumerable<CustomerType> CustomerType { get; set; }
        public virtual IEnumerable<Estate> Estates { get; set; }
    }

}