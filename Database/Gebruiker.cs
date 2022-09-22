namespace Database;
using System.ComponentModel.DataAnnotations.Schema;
class Gebruiker
{
    public int Id {get; set;}
    public string Email {get; set;}
    
    public Gebruiker(string email)
    {
        Email = email;
    }
}