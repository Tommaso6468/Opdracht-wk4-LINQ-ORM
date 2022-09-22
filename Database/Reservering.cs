namespace Database;
class Reservering
{
    public int ReserveringId {get; set;}
    public Gast? gast {get; set;}
    public DateTimeBereik dateTimeBereik {get; set;}
    public List<Attractie> Attracties {get; set;}
}