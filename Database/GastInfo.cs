namespace Database;
class GastInfo
{
    public int Id {get; set;}
    public int GastId {get; set;}
    public Gast gast {get; set;}
    public string? LaatstBezochteUrl {get; set;}
    public Coordinate Coordinaat {get; set;}

}