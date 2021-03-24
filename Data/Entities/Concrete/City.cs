using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities.Concrete
{
    [Table("Cities")]
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
