namespace Database;
using Microsoft.EntityFrameworkCore;

class DatabaseContext : DbContext
{
    public DbSet<Gebruiker> Gebruikers { get; set; }
    public DbSet<Gast> Gasten { get; set; }
    public DbSet<Medewerker> Medewerkers { get; set; }
    public DbSet<Reservering> Reserveringen { get; set; }
    public DbSet<Attractie> Attracties { get; set; }
    public DbSet<Onderhoud> Onderhoud { get; set; }
    public DbSet<GastInfo> GastInfos { get; set; }
    // public DbSet<MedewerkerOnderhoud> MedewerkerOnderhoud { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // builder.UseSqlServer(@"Server=PCT\SQLEXPRESS;Database=a;Trusted_Connection=True;");
        builder.UseSqlite("Data Source=database.db");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // builder.Entity<Gebruiker>().Property(e => e.Email).IsRequired();
        // builder.Entity<Gast>().ToTable("Gasten");
        // builder.Entity<Medewerker>().ToTable("Medewerkers");
        // builder.Entity<Attractie>().HasKey(a => a.AttractieId);
        // builder.Entity<Gast>().HasOne(g => g.GastInfo).WithOne(g => g.gast).HasForeignKey<GastInfo>(g => g.Id);


        // builder.Entity<Gebruiker>().ToTable("Gebruikers");
        builder.Entity<Gast>().ToTable("Gasten");
        builder.Entity<Medewerker>().ToTable("Medewerkers");

        builder.Entity<Medewerker>()
            .HasMany(m => m.Coordineert)
            .WithMany(o => o.Coordineert)
            .UsingEntity(j => j.ToTable("MedewerkerOnderhoudCoordineert"));

        builder.Entity<Medewerker>()
            .HasMany(m => m.Doet)
            .WithMany(o => o.Doet)
            .UsingEntity(j => j.ToTable("MedewerkerOnderhoudDoet"));    
    }

    public async Task<bool> Boek(Gast g, Attractie a, DateTimeBereik d)
    {
        return true;
    }

}