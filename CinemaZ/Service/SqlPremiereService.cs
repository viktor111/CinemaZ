using CinemaZ.Data;
using CinemaZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Service
{
    public class SqlPremiereService : ISqlPremiereService
    {
        private ApplicationDbContext _dbContext;

        public SqlPremiereService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Premiere CreatePremiere(Premiere premiere)
        {
            _dbContext.Premiere.Add(premiere);

            _dbContext.SaveChanges();

            return new Premiere();
        }

        public Premiere DeletePremiere(Premiere premiere)
        {
            _dbContext.Premiere.Remove(premiere);

            _dbContext.SaveChanges();

            return new Premiere();
        }

        public Premiere EdditPremiere(Premiere premiere)
        {
            Premiere premiereToEdit = _dbContext.Premiere.Where(p => p.Id == premiere.Id).FirstOrDefault();

            premiereToEdit.Movie = premiere.Movie;
            premiereToEdit.PremiereDate = premiere.PremiereDate;
            premiereToEdit.EndDate = premiere.EndDate;
            premiereToEdit.Discount = premiere.Discount;

            return new Premiere();
        }

        public Premiere GetPremiere(int id)
        {
            return _dbContext.Premiere.Where(p => p.Id == id).FirstOrDefault();
        }

        public List<Premiere> ListPremieres()
        {
            return _dbContext.Premiere.OrderBy(p => p.PremiereDate).ToList();
        }
    }
}
