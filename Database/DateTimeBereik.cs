using Microsoft.EntityFrameworkCore;

namespace Database;
[Owned]
class DateTimeBereik
{
    public DateTime Begin { get; set; }
    public DateTime? Eind { get; set; }

    public bool Eindigt()
    {
        return false;
    }

    public bool Overlapt(DateTimeBereik that)
    {

        if (that.Begin > this.Begin && that.Begin < this.Eind) { return true; }
        if (that.Eind > this.Begin && that.Eind < this.Eind) { return true; }
        if (that.Begin < this.Begin && that.Eind > this.Eind) { return true; }
        if (that.Begin == this.Begin && that.Eind == this.Eind) { return true; }

        return false;

    }
}