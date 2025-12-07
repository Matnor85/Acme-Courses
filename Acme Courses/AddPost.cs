using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Acme_Courses;

public class AddPost()
{
    //string tabell = tabellNamn;

    static ApplicationContext context = new ApplicationContext();

    public static void AddKursManuellt()
    {
        Console.Clear();
        string[] sa =
            [ "==== Add new course ====\n",
              "",
              "Enter course name: "];
        ConsoleHelper.CenterMenu(sa);
        ConsoleHelper.SetCursor(3, 0);
        string namn = Console.ReadLine()!.Trim();

        Console.Clear();
        ConsoleHelper.CenterAll("Enter description: ");
        ConsoleHelper.SetCursor(1, 0);
        string beskrivning = Console.ReadLine()!.Trim();

        Console.Clear();
        ConsoleHelper.CenterAll("Enter start date (YYYY-MM-DD): ");
        ConsoleHelper.SetCursor(1, 0);
        DateOnly startDatum;

        while (!DateOnly.TryParse(Console.ReadLine(), out startDatum))
        {
            Console.Clear();
            ConsoleHelper.CenterAll("Invalid format! Please try again (YYYY-MM-DD): ");
        }

        Console.Clear();
        ConsoleHelper.CenterAll("Enter end date (YYYY-MM-DD): ");
        ConsoleHelper.SetCursor(1, 0);
        DateOnly slutDatum;

        while (!DateOnly.TryParse(Console.ReadLine(), out slutDatum))
        {
            Console.Clear();
            ConsoleHelper.CenterAll("Invalid format! Please try again (YYYY-MM-DD): ");
        }

        List<string> educationList = new List<string>();
        Console.Clear();
        foreach (var edu in context.Utbildningar)
        {
            educationList.Add($"{edu.ID}. {edu.Namn}");
        }
        educationList.Sort();
        educationList.Add("");
        educationList.Add("Enter Education ID:");

        ConsoleHelper.SetCursor(4, 19);// fixa pointer
        Console.Clear();
        ConsoleHelper.CenterBlock(educationList);
        int utbildningID;
        while (!int.TryParse(Console.ReadLine(), out utbildningID))
        {
            Console.Clear();
            ConsoleHelper.CenterAll("Invalid choice! Please enter a number: ");
        }

        List<string> instructorList = new List<string>();
        foreach (var instructor in context.Kursledare)
        {
            instructorList.Add($"{instructor.ID}. {instructor.Förnamn} {instructor.Efternamn}");
        }
        instructorList.Sort();
        instructorList.Add("");
        instructorList.Add("Enter the Instructor's ID:");

        Console.Clear();
        ConsoleHelper.CenterBlock(instructorList);
        ConsoleHelper.SetCursor(3, 0);
        int kursledareID;
        while (!int.TryParse(Console.ReadLine(), out kursledareID))
        {
            Console.Clear();
            ConsoleHelper.CenterAll("Invalid choice! Please enter a number: ");
        }
        Console.Clear();
        ConsoleHelper.CenterAll("\nAre you sure you want to add this course? (Y/N)");
        var key = Console.ReadKey(true).Key;

        if (key != ConsoleKey.Y)
        {
            Console.Clear();
            ConsoleHelper.CenterAll("Cancelled.");
            return;
        }
        var kl = new Kursledare();

        var course = new Kurs()
        {
            Namn = namn,
            Beskrivning = beskrivning,
            StartDatum = startDatum,
            SlutDatum = slutDatum,
            UtbildningID = utbildningID,
            KursledareID = kursledareID
        };

        context.Kurser.Add(course);
        context.SaveChanges();

        string[] end =
            [$"\n{namn} Added!",
             "",
             "",
             "Press any key to continue..."];
        ConsoleHelper.CenterMenu(end);
        Console.ReadKey(true);
    }


    public static void AddTo()
    {
            var std = new Elev()
            {
                Förnamn = "Bill",
                Efternamn = "Gates"
                //Kontaktuppgifter och Utbildning?
            };
            context.Elever.Add(std);
        
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
