using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hangman_The_Fun_Version;

namespace Acme_Courses;

internal class Meny
{
    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            ShowMainMenu();
            ConsoleHelper.Sound();

            Console.WriteLine();
            Console.Write("Välj: ");
            var choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1": ShowUtbildningar(); break;
                case "2": ShowElever(); break;
                case "3": ShowKurser(); break;
                case "0": exit = true; break;
                default: Console.WriteLine("Ogiltigt val"); break;
            }
        }
    }

    private void ShowMainMenu()
    {
        Console.Clear();
        string[] lines = new[]
        {
            "ACME COURSES",
            "",
            "1) Visa Utbildningar",
            "2) Visa Elever",
            "3) Visa Kurser",
            "",
            "0) Avsluta"
        };

        ConsoleHelper.CenterMenu(lines);
    }

    private void ShowUtbildningar()
    {
        
    }

    private void ShowElever()
    {
        Console.Clear();
       
    }

    private void ShowKurser()
    {
       
    }

    private void PromptReturn()
    {
       
    }

    private void ShowTemporaryMessage()
    {
       
    }
}
