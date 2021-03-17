using Data.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Concrete
{
    public class Estate : IEntity
    {
        public int Id { get; set; }
        public EstateType EstateType { get; set; }
        public double SquareMeter { get; set; }
        public int NumberOfRooms { get; set; }
        public int Floor { get; set; }
        public int TotalNumberOfBuildingFloors { get; set; }
        public HeatingType HeatingType { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
    public enum EstateType
    {
        ForSale = 1,
        ForRent = 2
    }
    public enum HeatingType
    {
        None = 0,
        Boilers = 1,
        CentralHeating = 2,
        AirConditioning = 3,
        Stove = 4
    }
}
