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



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
        .AddJsonFile("AppSettings.json")
        .Build();

        // Läs vår connection-string från konfigurations-filen
        var connStr = config.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connStr);
    }
}

