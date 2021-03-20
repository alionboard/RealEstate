﻿using Data.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Concrete
{
    public class Estate : IEntity
    {
        public int Id { get; set; }
        public double SquareMeter { get; set; }
        public int NumberOfRooms { get; set; }
        public int Floor { get; set; }
        public int TotalNumberOfBuildingFloors { get; set; }
        public int EstateTypeId { get; set; }
        public virtual EstateType EstateType { get; set; }
        public int HeatingTypeId { get; set; }
        public virtual HeatingType HeatingType { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }

}
