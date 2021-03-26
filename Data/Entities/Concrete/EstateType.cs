using Data.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities.Concrete
{
    [Table("EstateTypes")]

    public class EstateType:IType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        //ForSale = 1,
        //ForRent = 2
    }
}


