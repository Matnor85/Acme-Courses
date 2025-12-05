using System;
using System.Collections.Generic;
using System.Text;

namespace Acme_Courses;

public class AddPost ()
{
    //string tabell = tabellNamn;

    static ApplicationContext context = new ApplicationContext();


    public static void AddTo()
    {
            var std = new Elev()
            {
                Förnamn = "Bill",
                Efternamn = "Gates"
            };
            context.Elever.Add(std);
        
        AreYouSure();

    }

    private static void AreYouSure()
    {
        Console.WriteLine("Are you sure?: [Y] = YES or [N] for no");
        var choice = Console.ReadLine()?.ToUpper();

        if (choice == "Y")
        {
        context.SaveChanges();
        }
    }
}
