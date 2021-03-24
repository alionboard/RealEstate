using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities.Concrete
{
    [Table("CustomerTypes")]
    public class CustomerType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        //Buy = 1,
        //Sell = 2,
        //LeaseOut = 3,
        //LeaseIn = 4
    }
}
