namespace AdventureQuestRPG
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to Adventure Quest RPG!");
                Player player = new Player("Alz3bi");
                Wizard wizard = new Wizard("Wizard");
                BattleSystem battleSystem = new BattleSystem();
                battleSystem.StartBattle(player, wizard);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
