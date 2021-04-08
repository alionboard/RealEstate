using Business.Repositories;
using Data.Context;
using Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Services
{
    public class EstateManager : BaseRepository<Estate>, IEstateRepository
    {
        private readonly RealEstateDbContext _context;
        public EstateManager(RealEstateDbContext context) : base(context)
        {
            _context = context;
        }

        public Estate GetById(int id)
        {
            var estates = _context.Estates
                .Include(estate => estate.District).ThenInclude(district => district.City)
                .Include(estate => estate.EstateType)
                .Include(estate => estate.HeatingType)
                .Include(estate => estate.Customer);

            return estates.FirstOrDefault(x => x.Id == id);
        }

        public override IEnumerable<Estate> GetAll(Expression<Func<Estate, bool>> filter = null)
        {
            var estates = _context.Estates
                .Include(estate => estate.District).ThenInclude(district => district.City)
                .Include(estate => estate.EstateType);

            return estates.ToList();
        }
    }
}
