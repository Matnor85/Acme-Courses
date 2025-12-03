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

        //// Specificerar vilken datatyp databasen ska använda för en specifik kolumn
        //modelBuilder.Entity<Order>()
        //.Property(o => o.PriceTotal)
        //.HasColumnType(SqlDbType.Money.ToString());

        // Specificerar data som en specifik tabell ska för-populeras med
        modelBuilder.Entity<Utbildning>().HasData(
        new Utbildning { ID = 1, Namn = "BUV25", Beskrivning = "Backend-Utvecklare" },
        new Utbildning { ID = 2, Namn = "FUV25", Beskrivning = "Frontend-Utvecklare" },
        new Utbildning { ID = 3, Namn = "FSUV25", Beskrivning = "Fullstack-Utvecklare" }
        );
    }

}

