using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Acme_Courses;

public class ApplicationContext : DbContext
{
    //public DbSet<Kursledare> Lärare { get; set; } = null!;
    //public DbSet<Klass> Klasser { get; set; } = null!;
    public DbSet<Elev> Elever { get; set; } = null!;
    public DbSet<Kurs> Kurser { get; set; } = null!;
    public DbSet<Utbildning> Utbildningar { get; set; } = null!;
    public DbSet<KontaktUppgift> Kontaktuppgifter { get; set; } = null!;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
        .AddJsonFile("AppSettings.json")
        .Build();

        // Läs vår connection-string från konfigurations-filen
        var connStr = config.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connStr);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Specificerar vilken collation databasen ska använda
        modelBuilder.UseCollation("Finnish_Swedish_CI_AS");

        // Specificerar data som en specifik tabell ska för-populeras med
        modelBuilder.Entity<Utbildning>().HasData(
        new Utbildning { ID = 1, Namn = "BUV25", Beskrivning = "Backend-Utvecklare" },
        new Utbildning { ID = 2, Namn = "FUV25", Beskrivning = "Frontend-Utvecklare" },
        new Utbildning { ID = 3, Namn = "FSUV25", Beskrivning = "Fullstack-Utvecklare" }
        );

        // Kontaktuppgifter (seed) — varje Elev får både E-post och Telefon
        modelBuilder.Entity<KontaktUppgift>().HasData(
            // Elev 1 - Anna Andersson
            new KontaktUppgift { ID = 1, KontaktTyp = "E-post", KontaktInfo = "anna.andersson@example.com", ElevID = 1 },
            new KontaktUppgift { ID = 2, KontaktTyp = "Telefon", KontaktInfo = "070-1111111", ElevID = 1 },

            // Elev 2 - Björn Berg
            new KontaktUppgift { ID = 3, KontaktTyp = "E-post", KontaktInfo = "bjorn.berg@example.com", ElevID = 2 },
            new KontaktUppgift { ID = 4, KontaktTyp = "Telefon", KontaktInfo = "070-2222222", ElevID = 2 },

            // Elev 3 - Erik Eriksson
            new KontaktUppgift { ID = 5, KontaktTyp = "E-post", KontaktInfo = "erik.eriksson@example.com", ElevID = 3 },
            new KontaktUppgift { ID = 6, KontaktTyp = "Telefon", KontaktInfo = "070-3333333", ElevID = 3 },

            // Elev 4 - Sara Svensson
            new KontaktUppgift { ID = 7, KontaktTyp = "E-post", KontaktInfo = "sara.svensson@example.com", ElevID = 4 },
            new KontaktUppgift { ID = 8, KontaktTyp = "Telefon", KontaktInfo = "070-4444444", ElevID = 4 },

            // Elev 5 - Lina Lind
            new KontaktUppgift { ID = 9, KontaktTyp = "E-post", KontaktInfo = "lina.lind@example.com", ElevID = 5 },
            new KontaktUppgift { ID = 10, KontaktTyp = "Telefon", KontaktInfo = "070-5555555", ElevID = 5 },

            // Elev 6 - Oskar Olsson
            new KontaktUppgift { ID = 11, KontaktTyp = "E-post", KontaktInfo = "oskar.olsson@example.com", ElevID = 6 },
            new KontaktUppgift { ID = 12, KontaktTyp = "Telefon", KontaktInfo = "070-6666666", ElevID = 6 }
        );

        // Elever (seed)
        modelBuilder.Entity<Elev>().HasData(
            new Elev { ID = 1, Förnamn = "Anna", Efternamn = "Andersson" },
            new Elev { ID = 2, Förnamn = "Björn", Efternamn = "Berg" },
            new Elev { ID = 3, Förnamn = "Erik", Efternamn = "Eriksson" },
            new Elev { ID = 4, Förnamn = "Sara", Efternamn = "Svensson" },
            new Elev { ID = 5, Förnamn = "Lina", Efternamn = "Lind" },
            new Elev { ID = 6, Förnamn = "Oskar", Efternamn = "Olsson", }
        );
        modelBuilder.Entity("ElevUtbildning").HasData(
            new { EleverID = 1, UtbildningarID = 1 },
            new { EleverID = 2, UtbildningarID = 1 },
            new { EleverID = 3, UtbildningarID = 2 },
            new { EleverID = 4, UtbildningarID = 3 },
            new { EleverID = 5, UtbildningarID = 3 },
            new { EleverID = 6, UtbildningarID = 3 }
        );
        // Kurser (seed)
        modelBuilder.Entity<Kurs>().HasData(
            new Kurs { ID = 1, UtbildningID = 1, Namn = "C# Grund", Beskrivning = "Introduktion till C# och .NET", StartDatum = new DateTime(2025, 9, 1), SlutDatum = new DateTime(2025, 12, 15) },
            new Kurs { ID = 2, UtbildningID = 1, Namn = "SQL Grund", Beskrivning = "SQL Server och EF Core", StartDatum = new DateTime(2025, 9, 1), SlutDatum = new DateTime(2025, 11, 30) },
            new Kurs { ID = 3, UtbildningID = 2, Namn = "Frontend 1", Beskrivning = "HTML, CSS och JavaScript", StartDatum = new DateTime(2025, 9, 1), SlutDatum = new DateTime(2025, 12, 1) },
            new Kurs { ID = 4, UtbildningID = 2, Namn = "React Grund", Beskrivning = "Komponenter och state", StartDatum = new DateTime(2025, 10, 1), SlutDatum = new DateTime(2025, 12, 20) },
            new Kurs { ID = 5, UtbildningID = 3, Namn = "Fullstack Projekt", Beskrivning = "Bygg en komplett webbapplikation", StartDatum = new DateTime(2025, 9, 15), SlutDatum = new DateTime(2026, 1, 15) },
            new Kurs { ID = 6, UtbildningID = 3, Namn = "DevOps Introduktion", Beskrivning = "CI/CD och deployment", StartDatum = new DateTime(2025, 11, 1), SlutDatum = new DateTime(2026, 2, 1) }
        );
    }

}

