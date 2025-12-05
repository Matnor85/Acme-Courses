using System;
using System.Collections.Generic;
using System.Text;

namespace Acme_Courses;

public class AddPost (string tabellNamn)
{
    //string tabell = tabellNamn;

    static ApplicationContext context = new ApplicationContext();


    public static void AddTo(string tabellNamn)
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
        var choice = Console.ReadLine();

        if (true)
        {
        context.SaveChanges();
        }
    }
}
