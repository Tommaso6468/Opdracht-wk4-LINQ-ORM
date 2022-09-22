namespace Database;
class Medewerker : Gebruiker
{
    public ICollection<Onderhoud> Onderhoud {get; set;}
    public Medewerker(string email) : base(email) {}
}