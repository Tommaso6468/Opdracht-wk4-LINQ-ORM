using System.ComponentModel.DataAnnotations;
namespace Database;
class Attractie
{
    // [Key]
    public int AttractieId { get; set; }
    public string Naam { get; set; }

    public ICollection<Reservering> Reserveringen { get; set; }

    public Attractie(string naam)
    {
        Naam = naam;
    }

    public async Task<bool> OnderhoudBezig(DatabaseContext c)
    {
        foreach (var onderhoud in c.Onderhoud)
        {
            if (onderhoud.attractie == this)
            {
                return true;
            }
        }
        return false;
    }

    public async Task<bool> Vrij(DatabaseContext c, DateTimeBereik d)
    {
        foreach (var reservering in c.Reserveringen)
        {
            if (reservering.Attractie == this && reservering.dateTimeBereik.Overlapt(d))
            {
                return false;
            }
        }

        if (await OnderhoudBezig(c))
        {
            return false;
        }

        return true;
    }
}