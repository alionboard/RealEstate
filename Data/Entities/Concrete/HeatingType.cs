﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Concrete
{
    public class HeatingType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        //None = 0,
        //Boilers = 1,
        //CentralHeating = 2,
        //AirConditioning = 3,
        //Stove = 4
    }
}
