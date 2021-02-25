using CinemaZ.Data;
using CinemaZ.Models;
using System.Collections.Generic;
using System.Linq;

namespace CinemaZ.Service
{
    public class SqlPremiereService : ISqlPremiereService
    {
        private readonly ApplicationDbContext _dbContext;

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
            Premiere premiereToEdit = _dbContext.Premiere.FirstOrDefault(p => p.Id == premiere.Id);

            premiereToEdit.Movie = premiere.Movie;
            premiereToEdit.PremiereDate = premiere.PremiereDate;
            premiereToEdit.EndDate = premiere.EndDate;
            premiereToEdit.Discount = premiere.Discount;

            return new Premiere();
        }

        public Premiere GetPremiere(int id)
        {
            return _dbContext.Premiere.FirstOrDefault(p => p.Id == id);
        }

        public List<Premiere> ListPremieres()
        {
            return _dbContext.Premiere.OrderBy(p => p.PremiereDate).ToList();
        }
    }
}
