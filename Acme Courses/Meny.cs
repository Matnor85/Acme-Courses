using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    

namespace Acme_Courses;

internal class Meny
{
    public static void ShowMainMenu()
    {
        bool runMenu = true;
        while (runMenu)
        {

            string[] menu =
            ["Time Reporting System",
            "",
            "1. Lägg till anställd",
            "2. Logga timmar",
            "3. visa rapporter",
            "4. Ta bort anställd",
            "5. Exit",
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
                    AddEmployee();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    LogHours();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ShowReportsMenu();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    RemoveEmployee();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    Environment.Exit(0);
                    break;
                default:
                    ConsoleHelper.Sound();
                    ShowMainMenu();
                    break;
            }
        }
    }

    private static void RemoveEmployee()
    {
        Console.Clear();
        ConsoleHelper.CenterAll("Här kan du ta bort en anställd");

        Console.ReadLine();

    }

    private static void ShowReportsMenu()
    {
        Console.Clear();
        ConsoleHelper.CenterAll("Här kan du se alla rapporter");
        Console.ReadLine();

    }

    private static void LogHours()
    {
        Console.Clear();
        ConsoleHelper.CenterAll("Här kan du lägga till tid");
        Console.ReadLine();

    }

    private static void AddEmployee()
    {
        Console.Clear();
        ConsoleHelper.CenterAll("Här kan du lägga till anställd");
        Console.ReadLine();

    }
}
