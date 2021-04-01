using Business.Repositories;
using Data.Context;
using Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class EstateManager : BaseRepository<Estate>, IEstateRepository
    {
        public EstateManager(RealEstateDbContext context) : base(context)
        {

        }

        public Estate GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
