namespace AdventureQuestRPG
{
    public class Program
    {
        public static ConsoleKeyInfo input;
        static void Main(string[] args)
        {
            try
            {
                MainMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MainMenu()
        {
            string continueText = "press any key to continue...";
            Console.WriteLine("Welcome to Adventure Quest RPG!");
            Console.WriteLine(continueText);
            Console.ReadKey();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Start a new game (N)");
                Console.WriteLine("Load a saved Game (L)");
                Console.WriteLine("Quit (Q)");
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.N)
                {
                    Adventure adventure = new Adventure();
                    adventure.Game();
                }
                else if (input.Key == ConsoleKey.Q)
                {
                    Exit();
                }
                else if (input.Key == ConsoleKey.L)
                {
                    LoadGame();
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
        public static void Exit()
        {
            Console.Clear();
            const string quitMessage = "Are you sure you want to quit? (Y/N)";
            Console.WriteLine(quitMessage);
            while (true)
            {
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.Y)
                {
                    Environment.Exit(0);
                }
                else if (input.Key == ConsoleKey.N)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
        public static void LoadGame()
        {
            Console.Clear();
            Console.WriteLine("Loading Game...");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
