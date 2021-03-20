using Business.Repositories;
using Data.Context;
using Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class WorkplaceManager : BaseRepository<Workplace>, IWorkPlaceRepository
    {
        public WorkplaceManager(RealEstateDbContext context) : base(context)
        {

        }
    }
}
