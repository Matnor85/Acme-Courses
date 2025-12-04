namespace Acme_Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Meny meny = new Meny();
            Meny.ShowMainMenu();
        }
    }
}
