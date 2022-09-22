namespace Database;
using Microsoft.EntityFrameworkCore;

class DatabaseContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Gast>().ToTable("Gasten");
        builder.Entity<Medewerker>().ToTable("Medewerkers");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(@"Server=PCT\SQLEXPRESS;Database=week4;Trusted_Connection=True;");
    }

    public DbSet<Gebruiker> Gebruikers {get; set;}
    public DbSet<Gast> Gasten {get; set;}
    public DbSet<Medewerker> Medewerkers {get; set;}
    public DbSet<Reservering> Reserveringen {get; set;}
    public DbSet<Attractie> Attracties {get; set;}
    public DbSet<Onderhoud> Onderhoud {get; set;}
    public DbSet<GastInfo> GastInfo {get; set;}
}