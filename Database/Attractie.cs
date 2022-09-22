using System.ComponentModel.DataAnnotations;
namespace Database;
class Attractie
{
    // [Key]
    public int AttractieId;
    public string Naam;

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