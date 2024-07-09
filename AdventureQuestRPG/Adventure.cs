using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureQuestRPG
{
    public class Adventure
    {
        public List<Location> locations = new List<Location> { new Location("Town"), new Location("Forest"), new Location("Cave"), new Location("Castle") };
        public ConsoleKeyInfo input;
        public Player player = new Player("Alz3bi");
        //public Wizard wizard;
        //public BossMonster boss;
        //public List<Monster> monsters;
        public BattleSystem battleSystem = new BattleSystem();

        public Adventure()
        {
            //boss = new BossMonster("Boss");
            //wizard = new Wizard("Wizard");
            //monsters = new List<Monster> { wizard, wizard, wizard, wizard, wizard };
        }
        public void Game()
        {
            Console.Clear();
            Console.WriteLine("Starting Game...");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            while (true)
            {
                if (player.Health <= 0)
                {
                    return;
                }

                Console.Clear();
                Console.WriteLine("1. View my stats");
                Console.WriteLine("2. Choose a location");
                Console.WriteLine("3. view the inventory");
                Console.WriteLine("4. Equip an item from the inventory");
                Console.WriteLine("5. Save the game");
                Console.WriteLine("6. return to main menu");
                int choice = GetChoiceforGame();
                switch (choice)
                {

                    case 1:
                        playerStats();
                        break;
                    case 2:
                        Map();
                        break;
                    case 3:
                        ViewInventory();
                        break;
                    case 4:
                        EquipItem();
                        break;
                    case 5:
                        SaveGame();
                        break;
                    case 6:
                        return;
                }
            }
        }
        public void Map()
        {
            Console.Clear();
            Console.WriteLine("Avaliable locations: ");
            foreach (Location location in locations)
            {
                if (location.IsExplored)
                {
                    Console.WriteLine($"{locations.IndexOf(location) + 1}. {location.Name} (Explored)");
                }
                else
                {
                    Console.WriteLine($"{locations.IndexOf(location) + 1}. {location.Name}");
                }
            }
            int choice = GetChoiceforLocation();
            StartGame(locations[choice - 1]);

        }
        public void playerStats()
        {
            Console.Clear();
            Console.WriteLine("Player Stats");
            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Level: {player.Level}");
            Console.WriteLine($"XP: {player.XP}/{player.XpCap}");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Attack Power: {player.AttackPower}");
            Console.WriteLine($"Defense: {player.Defense}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void SaveGame()
        {
            Console.Clear();
            Console.WriteLine("Saving Game...");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void StartGame(Location location)
        {
            Console.Clear();
            Console.WriteLine($"You are in the {location.Name}");
            Console.WriteLine("Explore this location? (Y/N)");
            while (true)
            {
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.Y)
                {
                    Explore(location);
                    break;
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
        public void Explore(Location location)
        {
            Wizard wizard = new Wizard("Wizard");
            BossMonster bossMonster = new BossMonster("Boss");
            List<Monster> monsters = new List<Monster> { wizard, wizard, wizard, wizard, wizard, bossMonster };


            Console.Clear();
            Console.WriteLine($"You are exploring the {location.Name}");
            Random random = new Random();
            Console.WriteLine("You encountered a monster!");
            Monster monster = monsters[random.Next(0, monsters.Count)];
            //Monster monster = wizard;
            Console.WriteLine($"A {monster.Name} appeared!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();



            int result = battleSystem.StartBattle(player, monster);
            if (result == 1)
            {
                Console.Clear();
                Console.WriteLine("You won the battle!");
                location.IsExplored = true;
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You lost the battle!");
                Console.WriteLine("Game Over!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        public void ViewInventory()
        {
            Console.Clear();
            player.Inventory.DisplayInventory();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void EquipItem()
        {
            Console.Clear();
            if (player.Inventory.Items.Count == 0)
            {
                Console.WriteLine("Inventory is empty");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            player.Inventory.DisplayUnequippedItems();
            Console.WriteLine("Choose an Item to equip");
            int choice = GetChoiceforInventory(player.Inventory.Items);
            if (player.Inventory.Items[choice - 1] is Consumable)
            {
                player.UseConsumable((Consumable)player.Inventory.Items[choice - 1]);
                return;
            }
            if (player.Inventory.Items[choice - 1] is Armor)
            {
                player.EquipArmor((Armor)player.Inventory.Items[choice - 1]);
                return;
            }
            if (player.Inventory.Items[choice - 1] is Weapon)
            {
                player.EquipWeapon((Weapon)player.Inventory.Items[choice - 1]);
                return;
            }
            //player.EquipWeapon(player.Inventory.Items[choice - 1]);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public int GetChoiceforGame()
        {
            string? input = Console.ReadLine();
            bool success = Int32.TryParse(input, out int choice);
            while (!success || choice < 1 || choice > 6)
            {
                Console.WriteLine("Please enter a valid input");
                input = Console.ReadLine();
                success = Int32.TryParse(input, out choice);
            }
            return choice;
        }
        public int GetChoiceforLocation()
        {
            string? input = Console.ReadLine();
            bool success = Int32.TryParse(input, out int choice);
            while (!success || choice < 1 || choice > 4)
            {
                Console.WriteLine("Please enter a valid input");
                input = Console.ReadLine();
                success = Int32.TryParse(input, out choice);
            }
            return choice;
        }
        public int GetChoiceforInventory(List<Items> items)
        {
            string? input = Console.ReadLine();
            bool success = Int32.TryParse(input, out int choice);
            while (!success || choice < 1 || choice > player.Inventory.Items.Count)
            {
                Console.WriteLine("Please enter a valid input");
                input = Console.ReadLine();
                success = Int32.TryParse(input, out choice);
            }
            return choice;
        }
    }
    public class Location
    {
        public string Name { get; set; }
        public bool IsExplored { get; set; }
        public Location(string name)
        {
            Name = name;
        }
    }

}
