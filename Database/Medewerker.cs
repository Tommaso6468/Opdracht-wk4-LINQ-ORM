namespace Database;
// using System.ComponentModel.DataAnnotations.Schema;
class Medewerker : Gebruiker
{
    // [InverseProperty("Coordineert")]
    public ICollection<Onderhoud> Coordineert {get; set;}
    // [InverseProperty("Doet")]
    public ICollection<Onderhoud> Doet {get; set;}
    public Medewerker(string email) : base(email) {}
}