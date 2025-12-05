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
            .Where(std => std.Förnamn == "Bill")
            .Select(std => new { });
        
        context.Elever.Remove(std.Provider);

        AreYouSure();
    }

    private static void AreYouSure()
    {
        Console.Clear();
        ConsoleHelper.CenterAll("Are you sure?: [Y] = YES or [N] for no");
        Console.WriteLine();
        Console.WriteLine();

        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.KeyChar)
        {
            case 'Y':
                context.SaveChanges();
                break;
            case 'N':
                break;
            default:
                ConsoleHelper.CenterAll("Invalid input!");
                Thread.Sleep(1000);
                Console.Clear();
                return;
        }
    }
}
