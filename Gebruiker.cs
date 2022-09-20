class Gebruiker
{
    public int GebruikerId {get; set;}
    public readonly string Email;
    public Gebruiker(string email)
    {
        Email = email;
    }
}