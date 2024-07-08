using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureQuestRPG
{
    public class BattleSystem
    {
        public string Attack(IBattleStates attacker, IBattleStates target)
        {
            int damage = Math.Max(0, attacker.AttackPower - target.Defense);
            target.TakeDamage(damage);
            Console.WriteLine($"{attacker.Name} attacks {target.Name} for {damage} damage! {target.Name} Health: {target.Health}");
            return "Attack Complete!";
        }
        public int StartBattle(Player player, Monster enemy)
        {
            while(player.Health > 0 && enemy.Health > 0)
            {
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("player turn");
                Console.WriteLine(Attack(player, enemy));
                if(enemy.Health <= 0)
                {
                    Console.WriteLine($"You defeated the {enemy.Name}");
                    string continueText = "press any key to continue...";
                    Console.WriteLine(continueText);
                    Console.ReadKey();
                    player.restoreHealth();
                    player.GainXP(enemy.DefeatXp);
                    return 1;
                }
                Console.WriteLine();
                Console.WriteLine("enemy turn");
                Console.WriteLine(Attack(enemy,player));
                if (player.Health <= 0)
                {
                    Console.WriteLine($"You were defeated by {enemy.Name}");
                    string continueText = "press any key to continue...";
                    Console.WriteLine(continueText);
                    Console.ReadKey();
                    return 0;
                }
                
            }
            return 1;
        }


    }
}
