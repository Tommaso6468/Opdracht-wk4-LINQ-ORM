namespace Database;
class Onderhoud
{
    public int OnderhoudId {get; set;}
    public DateTimeBereik dateTimeBereik {get; set;}
    public string Probleem {get; set;}
    public Attractie attractie {get; set;}
    public ICollection<Medewerker> Coordineert {get; set;}
    public ICollection<Medewerker> Doet {get; set;}
}