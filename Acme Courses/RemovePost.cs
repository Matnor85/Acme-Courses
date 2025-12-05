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
        var std = context.Elever
            .FirstOrDefault(e => e.Förnamn == "Bill");

        if (std == null)
        {
            ConsoleHelper.CenterAll("Student not found!");
            return;
        }

            context.Elever.Remove(std);

        AreYouSure();
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
