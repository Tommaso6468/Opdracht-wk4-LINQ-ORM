using Microsoft.EntityFrameworkCore;

namespace Database;
[Owned]
class Coordinate
{
    public int X {get; set;}
    public int Y {get; set;}

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
}