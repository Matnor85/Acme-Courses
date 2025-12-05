using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;


namespace Acme_Courses;

internal class Meny
{
    static ApplicationContext context = new ApplicationContext();
    public static void ShowMainMenu()
    {
        bool runMenu = true;
        while (runMenu)
        {

            string[] menu =
            ["Acme school",
            "",
            "1. Show all studens",
            "2. Show all courses",
            "3. Show all educations",
            "4. Exit",
            "",
            "Please select an option: "];
            Console.Clear();
            ConsoleHelper.CenterMenu(menu);
            ConsoleHelper.SetCursor(4, 11);
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    ShowAllStudents();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ShowAllCourses();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ShowAllEducations();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Environment.Exit(0);
                    break;
                default:
                    ConsoleHelper.Sound();
                    ConsoleHelper.CenterAll("invalid choice");
                    break;
            }
        }
    }

    private static void ShowAllEducations()
    {
        Console.Clear();
        string[] menu =
           ["educations",
            "",
            "1. Show all educations",
            "2. Add education",
            "3. Remove education",
            "4. Back",
            "",
            "Please select an option: "];
        Console.Clear();
        ConsoleHelper.CenterMenu(menu);
        ConsoleHelper.SetCursor(4, 11);
        ConsoleKeyInfo key = Console.ReadKey(true);
        bool run = true;
        while (run)
        {

            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Clear();
                    var utbildningar = context.Utbildningar
                    .Select(u => $"{u.ID}. {u.Namn}")
                    .ToList();
                    ConsoleHelper.CenterAll(string.Join("\n", utbildningar));

                    ConsoleHelper.CenterAll("Select education for information:\n");
                    ConsoleHelper.SetCursor(13, 0);
                    var input = int.TryParse(Console.ReadLine()!, out int yada);
                    
                    if(input!) { /*break;*/ }

                    var utbildning = context.Utbildningar.Find(yada);
                    var qa = context.Utbildningar
                        .Where(u => u.ID == yada)
                        .Select(u => new { u.ID, u.Namn, u.Beskrivning })
                        .ToList();
                    if (utbildning is null)
                    {
                        Console.Clear();
                        ConsoleHelper.CenterAll("Invalide choice!");
                        Console.ReadLine();
                        break;
                    }
                    Console.Clear();
                    var utbild = new[]
                    {
                        $"{utbildning.ID} - {utbildning.Namn}",
                        "",
                        "Information:",
                        utbildning.Beskrivning ?? "(No inforamtion for this education)",
                        "",
                        "Press Enter to return."
                    };
                    ConsoleHelper.CenterAll(string.Join("\n", utbild));
                    Console.ReadLine();
                    ShowAllEducations();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:

                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:

                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                run = false;
                    ShowMainMenu();
                    break; 

                default:
                    ConsoleHelper.Sound();
                    ConsoleHelper.CenterAll("invalid choice");
                    break;
            }
        }

    }


    private static void ShowAllCourses()
    {
        Console.Clear();
        string[] menu =
           ["courses",
            "",
            "1. Show all courses",
            "2. Add course",
            "3. Remove course",
            "4. Back",
            "",
            "Please select an option: "];
        Console.Clear();
        ConsoleHelper.CenterMenu(menu);
        ConsoleHelper.SetCursor(4, 11);
        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.Key)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                Console.Clear();
               // var kurser = context.Kurser;
               // var utbild = new[]
               //{
               //     $"{} - {utbildning.Namn}",
               //     "",
               //     "Information:",
               //     utbildning.Beskrivning ?? "(No inforamtion for this education)",
               //     "",
               //     "Press Enter to return."
               // };
                //ConsoleHelper.CenterAll(string.Join("\n", utbild));
                var kurser = context.Kurser.ToList();
                List<string> kursLísta = new List<string>();
                foreach (var kurs in kurser)
                {
                    var q = $"{kurs.Namn}";
                    var t = $"course info: {kurs.Beskrivning}";
                    var r = $"Start: {kurs.StartDatum} Ends: {kurs.SlutDatum}";
                    kursLísta.Add(q);
                    kursLísta.Add(t);
                    kursLísta.Add(r);
                    kursLísta.Add("");
                    //foreach (var kursinfo in kurser)
                    //{
                    //    var b = $" {kursinfo.Beskrivning}";
                    //    var c = $" {kursinfo.StartDatum} - {kursinfo.SlutDatum}";
                    //    kursLísta.Add(b);
                    //    kursLísta.Add(c);

                    //}

                    // Lägg till en tom rad för mellanrum
                }
                ConsoleHelper.CenterBlock(kursLísta);
                Console.ReadLine();
                break;
            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                ShowAllCourses();
                break;
            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:
                ShowAllEducations();
                break;
            case ConsoleKey.D4:
            case ConsoleKey.NumPad4:
                return;
            default:
                ConsoleHelper.Sound();
                ConsoleHelper.CenterAll("invalid choice");
                break;
        }

    }

    private static void ShowAllStudents()
    {
        Console.Clear();
        string[] menu =
            ["studens",
            "",
            "1. Show all studens",
            "2. Contact informations",
            "3. Add student",
            "4. Remove student",
            "5. Back",
            "",
            "Please select an option: "];
        Console.Clear();
        ConsoleHelper.CenterMenu(menu);
        ConsoleHelper.SetCursor(4, 11);
        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.Key)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                Console.Clear();


                var fullNames = context.Elever
                    .Select(e => $"{e.Förnamn} {e.Efternamn}")
                    .ToList();

                if (fullNames.IsNullOrEmpty())
                {
                    ConsoleHelper.CenterAll("No students found.");
                }
                else
                {
                    ConsoleHelper.CenterBlock(fullNames);
                }

                Console.ReadLine();
                break;
            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                ContactInformations();
                break;
            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:

                break;
            case ConsoleKey.D4:
            case ConsoleKey.NumPad4:

                break;
            case ConsoleKey.D5:
            case ConsoleKey.NumPad5:
                return;
            default:
                ConsoleHelper.Sound();
                ConsoleHelper.CenterAll("invalid choice");
                break;
        }
    }
    public static void ContactInformations()
    {
        Console.Clear();
        var elever = context.Elever.Include(s => s.KontaktUppgifter).ToList();
        List<string> elevLísta = new List<string>();
        foreach (var elev in elever)
        {
            var q = $"{elev.Förnamn} {elev.Efternamn}";
            elevLísta.Add(q);

            foreach (var kontakt in elev.KontaktUppgifter)
            {
                var b = $" {kontakt.KontaktTyp}: {kontakt.KontaktInfo}";
                elevLísta.Add(b);
            }

            // Lägg till en tom rad för mellanrum
            elevLísta.Add("");
        }
        ConsoleHelper.CenterBlock(elevLísta);
        Console.ReadLine();

    }


}
