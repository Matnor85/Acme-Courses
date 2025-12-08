using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Acme_Courses;

public class RemovePost()
{
    static ApplicationContext context = new ApplicationContext();

    public static void RemoveFrom(string nameOfKlass)
    {
        if (nameOfKlass == "Students")
        {
            var namn = StudentChoice();

            var elevToRemove = context.Elever
                .FirstOrDefault(e => e.Förnamn == namn.förnamn && e.Efternamn == namn.efternamn);

            context.Elever.Remove(elevToRemove!);

            if (elevToRemove == null!)
            {
                ConsoleHelper.CenterAll("Student not found!");
                return;
            }
            AreYouSure();
        }
        else if (nameOfKlass == "Kurs")
        {
            var namn = CourseChoice();

            var kursToRemove = context.Kurser
                .FirstOrDefault(e => e.Namn == namn);

            context.Kurser.Remove(kursToRemove!);

            AreYouSure();
        }
        else
        {
            Console.WriteLine("Invalid name of klass given");
            Thread.Sleep(1500);
        }
    }
    private static string CourseChoice()
    {
        Console.Clear();
        var q = context.Kurser
            .Select(q => new { q.ID, q.Namn })
            .OrderBy(q => q.ID);
        List<string> kursList = new List<string>();
        List<string> kursNamn = new List<string>();
        List<int> ID = new List<int>();
        int i = 1;
        foreach (var item in q)
        {
            kursList.Add($"{i} {item.Namn}");
            kursNamn.Add($"{item.Namn}");
            ID.Add(item.ID);
            i++;
        }

        ConsoleHelper.CenterBlock(kursList);
        ConsoleHelper.OscarOchAron("Enter the number of the course you wish to edit: ");
        var position = Console.GetCursorPosition();
        Console.SetCursorPosition(position.Left-34, position.Top);
        string key = Console.ReadLine()!;
        int input;
        while (!int.TryParse(key, out input) && 0 <= input && input <= ID.Count()) {
            Console.WriteLine("Invalid Id");
            key = Console.ReadLine()!;
        }
        var kurs = kursNamn[input-1];
        return kurs;
    }
    private static (string förnamn, string efternamn) StudentChoice()
    {
        Console.Clear();

        var q = context.Elever
            .Select(q => new { q.ID, q.Förnamn, q.Efternamn })
            .OrderBy(q => q.ID);
        List<string> elevList = new List<string>();
        List<int> ID = new List<int>();
        int i = 1;
        foreach (var item in q)
        {
            elevList.Add(string.Join($" {item.Förnamn} ", $"{i}", $"{item.Efternamn}"));
            ID.Add(item.ID);
            i++;
        }
        elevList.Add("");
        elevList.Add("");
        elevList.Add("Enter the number of the row you wish to edit: ");
        //ConsoleHelper.CenterBlock(elevList);
        Meny.PrintStuff(elevList);
        
        var position=Console.GetCursorPosition();
        Console.SetCursorPosition(position.Left+84, position.Top-1);
        string key = Console.ReadLine()!;

        if (int.TryParse(key, out int input))
        {
            if (input! <= ID.Count && input! >= 0)
            {
                //Hämtar listan ifrån den övre queryn och sedan specifierar vilket namn vi vill ha med yada ifrån TryParsen åvan.
                var namn = elevList[input-1];   
                var namnParts = namn.Split(' ');
                //delar upp stringen så vi kan använda den till queryn i RemoveFrom();
                
                string förnamn = namnParts[1];
                string efternamn = namnParts[2];
                return (förnamn, efternamn);
                
            }
            else
            {
                Console.WriteLine("Invalid ID not on the list");
                return StudentChoice();
            }
        }
        else
        {
            Console.WriteLine("Invalid ID");
                return StudentChoice();
        }
    }

    private static void AreYouSure()
    {
        Console.Clear();
        ConsoleHelper.CenterAll("Are you sure?: [Y] for YES or [N] for no");
        Console.WriteLine();
        Console.WriteLine();

        ConsoleKeyInfo key = Console.ReadKey(true);
            switch (char.ToLower(key.KeyChar))
            {
            case 'y':
                //this save not be saving. . .
                context.SaveChanges();
                break;
            case 'n':
                break;
            default:
                ConsoleHelper.CenterAll("Invalid input!");
                Thread.Sleep(1000);
                Console.Clear();
                return;
        }
    }
}
