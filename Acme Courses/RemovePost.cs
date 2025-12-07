using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Acme_Courses;

public class RemovePost()
{
    static ApplicationContext context = new ApplicationContext();

    public static void RemoveFrom()
    {
        var namn = UserChoice();
        Console.WriteLine(namn.förnamn);
        var std = context.Elever
            .Select(e => new { e.Förnamn, e.Efternamn })
            .Where(e => e.Förnamn == namn.förnamn && e.Efternamn == namn.efternamn);

        if (std == null)
        {
            ConsoleHelper.CenterAll("Student not found!");
            return;
        }

        AreYouSure();
    }

    private static (string förnamn, string efternamn) UserChoice()
    {
        Console.Clear();

        var q = context.Elever
            .Select(q => new { q.ID, q.Förnamn, q.Efternamn })
            .OrderBy(q => q.ID);
        List<string> elevList = new List<string>();
        List<int> ID = new List<int>();
        foreach (var item in q)
        {
            elevList.Add(string.Join($" {item.Förnamn} ", $"{item.ID}", $"{item.Efternamn}"));
            ID.Add(item.ID);
        }
        ConsoleHelper.CenterBlock(elevList);

        ConsoleHelper.CenterAll("Enter the number of the row you wish to edit.");
        ConsoleKeyInfo key = Console.ReadKey(true);

        if (int.TryParse(key.KeyChar.ToString(), out int yada))
        {
            if (yada <= ID.Count && yada >= 0)
            {
                //Hämtar listan ifrån den övre queryn och sedan specifierar vilket namn vi vill ha med yada ifrån TryParsen åvan.
                var namn = elevList[yada];   
                var namnParts = namn.Split(' ');
                //delar upp stringen så vi kan använda den till queryn i RemoveFrom();
                if (namnParts.Length >= 3)
                {
                    string förnamn = namnParts[1];
                    string efternamn = namnParts[2];
                    return (förnamn, efternamn);
                }
                else
                {
                    throw new Exception("Invalid name format");
                }
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                throw new Exception("Invalid ID");
            }
            throw new Exception("Sitt på en kaktus");
        }
        throw new Exception("Sitt på en kaktus");
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
