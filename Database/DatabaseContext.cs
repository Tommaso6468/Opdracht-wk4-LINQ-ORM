namespace Database;
using Microsoft.EntityFrameworkCore;

class DatabaseContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Gast>().ToTable("Gasten");
        builder.Entity<Medewerker>().ToTable("Medewerkers");
        builder.Entity<Attractie>().HasKey(a => a.AttractieId);
        builder.Entity<Gast>().HasOne(g => g.GastInfo).WithOne(g => g.gast).HasForeignKey<GastInfo>(g => g.GebruikerId);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(@"Server=PCT\SQLEXPRESS;Database=a;Trusted_Connection=True;");
    }

    public DbSet<Gebruiker> Gebruikers {get; set;}
    public DbSet<Gast> Gasten {get; set;}
    public DbSet<Medewerker> Medewerkers {get; set;}
    public DbSet<Reservering> Reserveringen {get; set;}
    public DbSet<Attractie> Attracties {get; set;}
    public DbSet<Onderhoud> Onderhoud {get; set;}
    public DbSet<GastInfo> GastInfo {get; set;}
}