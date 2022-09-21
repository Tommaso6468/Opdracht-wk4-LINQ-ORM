using System;

namespace Database;
class Gast : Gebruiker
{
    public int Credits {get; set;}
    public DateTime GeboorteDatum {get; set;}
    public DateTime EersteBezoek {get; set;}

    public ICollection<Reservering> Reserveringen {get; set;}

    public Gast(string email) : base(email) {}
    
    public void Boek(){

    }
}