using Data.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities.Concrete
{
    public class CustomerTypeCustomer : IType
    {
        public int CustomerTypeId { get; set; }
        public virtual CustomerType CustomerType { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
