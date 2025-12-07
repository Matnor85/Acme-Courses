using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;

namespace Acme_Courses;

public class AddPost()
{
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

    /*---------------------------------------------------------------------------------*/

    public static void AddTo()
    {
        int intCheck = 0;

        Console.Clear();
        ConsoleHelper.CenterAll("Enter here the entire namne of the new student: ");
        Console.SetCursorPosition(Console.WindowWidth / 2 + "Enter here the entire namne of the new student: ".Length / 2, Console.WindowHeight / 2);
        var namn = Console.ReadLine();
        var namnParts = namn!.Split(' ');
        if (namnParts.Length == 2)
        {
            var std = new Elev()
            {
                Förnamn = $"{namnParts[0]}",
                Efternamn = $"{namnParts[1]}"
            };
            context.Elever.Add(std);

            intCheck = AreYouSure();
            while (intCheck == 1)
            { 
            //}
            //if (intCheck == 1)
            //{
                Console.Clear();
                var q = context.Elever
                    .Where(q => q.Förnamn == namnParts[0] && q.Efternamn == namnParts[1])
                    .Select(q => q.ID);
                var elevID = 0;
                foreach (var item in q) { elevID = item; }

                var kontaktTyp = "";
                string EmailMobilNumber = "";

                kontaktTyp = "E-post";
                string[] menu =
                   ["==== Choose an Email address ====",
                    "(leave the field blank if you don't wish to enter an email at this time)"];
                ConsoleHelper.CenterMenu(menu);
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + 3);
                EmailMobilNumber = Console.ReadLine()!;
                Console.Clear();
                if (EmailMobilNumber.IsNullOrEmpty())
                    EmailMobilNumber = null!;
                var std2 = new KontaktUppgift()
                {
                    KontaktTyp = $"{kontaktTyp}",
                    KontaktInfo = $"{EmailMobilNumber}",
                    ElevID = elevID
                };
                context.Kontaktuppgifter.Add(std2);

                kontaktTyp = "Telefon";
                string[] menu2 =
                   ["==== Choose a Phonenumber====",
                "(leave the field blank if you don't wish to enter an email at this time)"];
                ConsoleHelper.CenterMenu(menu2);
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + 3);
                EmailMobilNumber = Console.ReadLine()!;
                Console.Clear();
                if (EmailMobilNumber.IsNullOrEmpty())
                    EmailMobilNumber = null!;
                var std3 = new KontaktUppgift()
                {
                    KontaktTyp = $"{kontaktTyp}",
                    KontaktInfo = $"{EmailMobilNumber}",
                    ElevID = elevID
                };
                context.Kontaktuppgifter.Add(std3);
                Console.Clear();
                string[] Check =
                [
                    $"You are about to add the following student:",
                     $"Name: {namn}",
                     $"Email: {std2.KontaktInfo}",
                     $"Phone: {std3.KontaktInfo}",
                ];

                ConsoleHelper.CenterMenu(Check);
                AreYouSure();
            }
            /*else */if (intCheck == 2) { Meny.ShowAllStudents(); }
            else
            {
                ConsoleHelper.CenterAll("Invalid input!");
                Thread.Sleep(1500);
                Console.Clear();
                AreYouSure();
            }
        }
        else
        {
            Console.WriteLine("The name your entering must only be a two parter");
            Thread.Sleep(2000);
            AddTo();
        }
    }

    private static int AreYouSure()
    {
        ConsoleHelper.CenterAll("Are you sure?: [Y] = YES or [N] for no");
        Console.WriteLine();
        Console.WriteLine();

        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (char.ToLower(key.KeyChar))
        {
            case 'y':
                context.SaveChanges();
                return 1;
            case 'n':
                //Meny.ShowAllStudents();
                context.Elever.Local.Clear();
                return 2;
            default:
                return 3;
        }
    }
}
