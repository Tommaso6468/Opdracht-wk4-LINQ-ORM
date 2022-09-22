namespace Database;
class Medewerker : Gebruiker
{
    public List<Onderhoud> Onderhoud {get; set;}
    public Medewerker(string email) : base(email) {}
}