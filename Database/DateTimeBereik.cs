using Microsoft.EntityFrameworkCore;

namespace Database;
[Owned]
class DateTimeBereik
{
    public DateTime Begin {get; set;}
    public DateTime? Eind {get; set;}

    public bool Eindigt()
    {
        //LOGIC
        return false;
    }

    public bool Overlapt(DateTimeBereik that)
    {
        //LOGIC
        return false;
    }
}