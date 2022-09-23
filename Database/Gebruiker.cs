namespace Database;
using System.ComponentModel.DataAnnotations.Schema;
class Gebruiker
{
    public int GebruikerId {get; set;}
    public string Email {get; set;}
    
    public Gebruiker(string email)
    {
        Email = email;
    }
}