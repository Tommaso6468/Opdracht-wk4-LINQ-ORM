﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class MainClass
{
    private static async Task<T> Willekeurig<T>(DbContext c) where T : class => await c.Set<T>().OrderBy(r => EF.Functions.Random()).FirstAsync();
    public static async Task Main(string[] args)
    {
        // Random random = new Random(1);
        // using (DatabaseContext c = new DatabaseContext())
        // {


        //     c.SaveChanges();

        //     foreach (string attractie in new string[] { "Reuzenrad", "Spookhuis", "Achtbaan 1", "Achtbaan 2", "Draaimolen 1", "Draaimolen 2" })
        //         c.Attracties.Add(new Attractie(attractie));

        //     c.SaveChanges();

        //     for (int i=0;i<40;i++)
        //         c.Medewerkers.Add(new Medewerker($"medewerker{i}@mail.com"));
        //     c.SaveChanges();

        //     for (int i = 0; i < 10000; i++)
        //     {
        //         var geboren = DateTime.Now.AddDays(-random.Next(36500));
        //         var nieuweGast = new Gast($"gast{i}@mail.com") { GeboorteDatum = geboren, EersteBezoek = geboren + (DateTime.Now - geboren) * random.NextDouble(), Credits = random.Next(5) };
        //         if (random.NextDouble() > .6)
        //             nieuweGast.Favoriet = await Willekeurig<Attractie>(c);
        //         c.Gasten.Add(nieuweGast);
        //     }
        //     c.SaveChanges();

        //     for (int i = 0; i < 10; i++)
        //         (await Willekeurig<Gast>(c)).Begeleider = await Willekeurig<Gast>(c);
        //     c.SaveChanges();


        //     Console.WriteLine("Finished initialization");

        //     Console.Write(await new DemografischRapport(c).Genereer());
        //     Console.ReadLine();
        // }

        var db = new DatabaseContext();
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        db.Attracties.RemoveRange(db.Attracties);
        db.Gebruikers.RemoveRange(db.Gebruikers);
        db.Gasten.RemoveRange(db.Gasten);
        db.Medewerkers.RemoveRange(db.Medewerkers);
        db.Reserveringen.RemoveRange(db.Reserveringen);
        db.Onderhoud.RemoveRange(db.Onderhoud);


        Random random = new Random(1);
        for (int i = 0; i < 40; i++)
            db.Medewerkers.Add(new Medewerker($"medewerker{i}@mail.com"));
        db.SaveChanges();

        for (int i = 0; i < 10000; i++)
        {
            var geboren = DateTime.Now.AddDays(-random.Next(36500));
            var nieuweGast = new Gast($"gast{i}@mail.com") { GeboorteDatum = geboren, EersteBezoek = geboren + (DateTime.Now - geboren) * random.NextDouble(), Credits = random.Next(5) };
            db.Gasten.Add(nieuweGast);
        }
        db.SaveChanges();

    }
}