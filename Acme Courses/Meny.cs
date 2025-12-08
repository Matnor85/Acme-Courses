using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

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
            ["==== Acme school ====",
            "",
            "1. Students",
            "2. Courses",
            "3. Educations",
            "4. Exit",
            "",
            "Please select an option: "];
            Console.Clear();
            //ConsoleHelper.CenterMenu(menu);
            //ConsoleHelper.SetCursor(4, 11);
            PrintStuff(menu);
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.KeyChar) // Main Menu
            {
                case '1':
                    ShowAllStudents();
                    break;
                case '2':
                    ShowAllCourses();
                    break;
                case '3':
                    ShowAllEducations();
                    break;
                case '4':
                    Environment.Exit(0);
                    break;
                default:
                    ConsoleHelper.Sound();
                    ConsoleHelper.CenterAll("Invalid choice");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }
    static int index;
    public static void PrintStuff(string[] menu)
    {
        var biggest = 1;
        for (int i = 1; i < menu.Length - 2; i++)
        {
            var size = menu[i].Length;
            if (size > biggest)
            {
                biggest = size;
                index2 = i;
            }
        }
        for (int i = 0; i < menu.Length; i++)
        {
            if (i == 0 || i == menu.Length-1)
                Console.SetCursorPosition((Console.WindowWidth / 2) - (menu[i].Length / 2), (Console.WindowHeight / 2) - (menu.Length / 2) + i);
            else
                Console.SetCursorPosition((Console.WindowWidth / 2) - (menu[index].Length / 2), (Console.WindowHeight / 2) - (menu.Length / 2) + i);

            Console.Write(menu[i]);
        }
    }
    static int index2;
    public static void PrintStuff(List<string> menu)
    {
        var biggest = 1;
        for (int i = 1; i < menu.Count-2; i++)
        {
            var size = menu[i].Length;
            if (size > biggest)
            {
                biggest = size;
                index2 = i;
            }
        }
        for (int i = 0; i < menu.Count(); i++)
        {
            if (i == 0 || i == menu.Count()-1)
                Console.SetCursorPosition((Console.WindowWidth / 2) - (menu[i].Length / 2), (Console.WindowHeight / 2) - (menu.Count() / 2) + i);
            else
                Console.SetCursorPosition((Console.WindowWidth / 2) - (menu[index2].Length / 2), (Console.WindowHeight / 2) - (menu.Count() / 2) + i);

            Console.Write(menu[i]);
        }
    }

    private static void ShowAllEducations()
    {
        Console.Clear();
        string[] menu =
           ["==== Educations ====",
            "",
            "1. Show all educations",
            "2. Back",
            "",
            "Please select an option: "];
        Console.Clear();

        while (true)
        {
            Console.Clear();
            PrintStuff(menu);
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.KeyChar) // Education Menu
            {
                case '1':
                    Console.Clear();
                    var utbildningar = context.Utbildningar
                    .Select(u => $"{u.Namn}")
                    .ToList();
                    List<string> utbildningarList = new List<string>();
                    utbildningarList.Add("==== Educations ====");
                    utbildningarList.Add("");
                    int i = 1;
                    foreach (var item in utbildningar)
                    {
                        utbildningarList.Add($"{i} {item}");
                        i++;
                    }
                    utbildningarList.Add("");
                    PrintStuff(utbildningarList);

                    ConsoleHelper.CenterAll("Select education for information:\n");
                    ConsoleHelper.SetCursor(13, 0);
                    ConsoleKeyInfo keyy = Console.ReadKey(true);
                    var input = int.TryParse(keyy.KeyChar.ToString(), out int keyInfo);

                    var utbildning = context.Utbildningar.Find(keyInfo);
                    var qa = context.Utbildningar
                        .Where(u => u.ID == keyInfo)
                        .Select(u => new { u.ID, u.Namn, u.Beskrivning })
                        .ToList();
                    if (utbildning is null)
                    {
                        Console.Clear();
                        ConsoleHelper.CenterAll("Invalid choice!");
                        Console.ReadKey(true);
                        break;
                    }

                    Console.Clear();
                    var utbild = context.Utbildningar.Include(u =>u.Elever);
                    List<string> newList = new List<string>();
                    newList.Add("==== Educations ====");
                    newList.Add("");
                    foreach (var ut in utbild)
                    {
                        if (ut.ID != keyInfo) continue;
                        newList.Add($"{ut.ID} {ut.Namn} {ut.Beskrivning}");

                        foreach (var elev in ut.Elever)
                        {
                            newList.Add($" {elev.Förnamn}: {elev.Efternamn}");
                        }
                    newList.Add("");
                    }

                    PrintStuff(newList);
                    Console.ReadKey(true);
                    ShowAllEducations();
                    break;
                case '2':
                    ShowMainMenu();
                    break; 

                default:
                    ConsoleHelper.Sound();
                    ConsoleHelper.CenterAll("Invalid choice");
                    Thread.Sleep(1500);
                    continue;
            }
        }
    }

    public static void ShowAllCourses()
    {
        Console.Clear();
        string[] menu =
           ["==== Courses ====",
            "",
            "1. Show all courses",
            "2. Add course",
            "3. Remove course",
            "4. Back",
            "",
            "Please select an option: "];
        Console.Clear();
        //ConsoleHelper.CenterMenu(menu);
        //ConsoleHelper.SetCursor(4, 11);
        PrintStuff(menu);
        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.KeyChar)
        {
            case '1':
                Console.Clear();
                var kurser = context.Kurser.Include(kl=>kl.Kursledare).ToList();
                List<string> kursLista = new List<string>();
                foreach (var kurs in kurser)
                {
                    kursLista.Add($"{kurs.Namn}");
                    kursLista.Add($"course info: {kurs.Beskrivning}");
                    kursLista.Add($"Start: {kurs.StartDatum} Ends: {kurs.SlutDatum}");
                    kursLista.Add($"Kursledare: {kurs.Kursledare?.Förnamn} {kurs.Kursledare?.Efternamn}");
                    kursLista.Add("");
                }

                ConsoleHelper.CenterBlock(kursLista);
                Console.ReadKey(true);
                break;
            case '2':
                AddPost.AddCourse();

                break;
            case '3':
                RemovePost.RemoveFrom("Kurs");
                break;
            case '4':
                ShowMainMenu();
                break;
            default:
                ConsoleHelper.Sound();
                ConsoleHelper.CenterAll("Invalid choice");
                Thread.Sleep(1500);
                break;
        }
    }

    public static void ShowAllStudents()
    {
        Console.Clear();
        string[] menu =
            ["==== Students ====",
            "",
            "1. Show all students",
            "2. Contact informations",
            "3. Add student",
            "4. Remove student",
            "5. Back",
            "",
            "Please select an option: "];
        Console.Clear();
        //ConsoleHelper.CenterMenu(menu);
        //ConsoleHelper.SetCursor(4, 11);
        PrintStuff(menu);
        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.KeyChar)
        {
            case '1':
                Console.Clear();
                //Cant keep up if you press to fast
                var fullNames = context.Elever
                    .Select(e => $"{e.Förnamn} {e.Efternamn}")
                    .ToList();

                if (fullNames.IsNullOrEmpty())
                {
                    ConsoleHelper.CenterAll("No students found.");
                }
                else
                {
                    List<string> NamesID = new List<string>();
                    NamesID.Add("==== Students ====");
                    NamesID.Add("");
                    int i = 1;
                    foreach (var item in fullNames)
                    {
                        NamesID.Add($"{i} {item}");
                            i ++;
                    }
                    NamesID.Add("");
                    PrintStuff(NamesID);
                }
                Console.ReadKey(true);
                break;

            case '2':
                ContactInformations();
                break;
            case '3':
                AddPost.AddTo();
                break;
            case '4':
                RemovePost.RemoveFrom("Students");
                break;
            case '5':
                break;
            default:
                ConsoleHelper.Sound();
                ConsoleHelper.CenterAll("Invalid choice");
                Thread.Sleep(1500);
                break;
        }
    }
    public static void ContactInformations()
    {
        Console.Clear();
        var elever = context.Elever.Include(s => s.KontaktUppgifter).ToList();
        List<string> elevLista = new List<string>();
        foreach (var elev in elever)
        {
            elevLista.Add($"{elev.Förnamn} {elev.Efternamn}"); 

            foreach (var kontakt in elev.KontaktUppgifter)
            {
                elevLista.Add($" {kontakt.KontaktTyp}: {kontakt.KontaktInfo}");
            }
            elevLista.Add("");
        }
        ConsoleHelper.CenterBlock(elevLista);
        Console.ReadKey(true);
    }
}