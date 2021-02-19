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
            throw new NotImplementedException();
        }

        public Premiere DeletePremiere(Premiere premiere)
        {
            throw new NotImplementedException();
        }

        public Premiere EdditPremiere(Premiere premiere)
        {
            throw new NotImplementedException();
        }

        public Premiere GetPremiere(int id)
        {
            throw new NotImplementedException();
        }

        public List<Premiere> ListPremieres()
        {
            throw new NotImplementedException();
        }
    }
}
