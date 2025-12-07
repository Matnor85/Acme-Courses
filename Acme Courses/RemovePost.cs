using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Acme_Courses;

public class RemovePost()
{
    //string tabell = tabellNamn;

    static ApplicationContext context = new ApplicationContext();


    public static void RemoveFrom()
    {
        UserChoice();
        var förnamn = UserChoice().förnamn;
        var efternamn = UserChoice().efternamn;
        var std = context.Elever
            .Select(e => new { e.Förnamn, e.Efternamn })
            .Where(e => e.Förnamn == förnamn && e.Efternamn == efternamn);


        if (std == null)
        {
            ConsoleHelper.CenterAll("Student not found!");
            return;
        }

        //context.Elever.Remove(std);

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
            elevList.Add(string.Join($" {item.Förnamn}", $"{item.ID}", $"{item.Efternamn}"));
            ID.Add(item.ID);
        }
        ConsoleHelper.CenterBlock(elevList);
        //ConsoleHelper.CenterMenu();

        ConsoleHelper.CenterAll("Enter the number of the row you wish to edit.");
        ConsoleKeyInfo key = Console.ReadKey(true);

        if (int.TryParse(key.KeyChar.ToString(), out int yada))
        {
            if (yada <= ID.Count && yada >= 0)
            {
                var que = context.Elever
                    .Select(x => new { x.ID, x.Förnamn, x.Efternamn })
                    .Where(x => x.ID == int.Parse(key.ToString()!));
                return (q.First().Förnamn, q.First().Efternamn);
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
        ConsoleHelper.CenterAll("Are you sure?: [Y] = YES or [N] for no");
        Console.WriteLine();
        Console.WriteLine();

        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (char.ToLower(key.KeyChar))
        {
            case 'y':
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
