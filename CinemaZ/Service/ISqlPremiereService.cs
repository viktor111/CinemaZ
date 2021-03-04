using CinemaZ.Models;
using System.Collections.Generic;

namespace CinemaZ.Service
{
    public interface ISqlPremiereService
    {
        Premiere GetPremiere(int id);

        Premiere CreatePremiere(Premiere premiere);

        Premiere DeletePremiere(Premiere premiere);

        List<Premiere> ListPremieres();

        Premiere EdditPremiere(Premiere premiere);
    }
}
