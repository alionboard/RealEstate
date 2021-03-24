using Data.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Concrete
{
    public class Workplace : IEntity
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public string Name { get; set; }
        public string AuthorizedPerson { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public int FaxNumber { get; set; }
    }
}
