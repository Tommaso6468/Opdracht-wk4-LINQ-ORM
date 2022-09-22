using System.ComponentModel.DataAnnotations;
namespace Database;
class Attractie
{
    // [Key]
    public int AttractieId {get; set;}
    public string Naam {get; set;}

    public Attractie(string naam)
    {
        Naam = naam;
    }

    public async Task<bool> OnderhoudBezig(DatabaseContext c)
    {
        //LOGIC
        return false;
    }

    public async Task<bool> Vrij(DatabaseContext c, DateTimeBereik d)
    {
        //LOGIC
        return false;
    }
} 