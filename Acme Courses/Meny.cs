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
                    ShowMainMenu();
                    break;
            }
        }
    }

    private static void ShowAllEducations()
    {
        Console.Clear();
        string[] menu =
           ["Acme school",
            "",
            "1. Show all studens",
            "2. Add student",
            "3. Remove student",
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
                return;
            default:
                ConsoleHelper.Sound();
                ShowMainMenu();
                break;
        }
    }

    private static void ShowAllCourses()
    {
        Console.Clear();
        string[] menu =
           ["Acme school",
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
                return;
            default:
                ConsoleHelper.Sound();
                ShowMainMenu();
                break;
        }

    }

    private static void ShowAllStudents()
    {
        Console.Clear();
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
                ShowMainMenu();
                break;
        }

    }
}
