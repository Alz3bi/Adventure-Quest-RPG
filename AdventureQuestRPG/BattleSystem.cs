using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureQuestRPG
{
    public class BattleSystem
    {
        public string Attack(Character attacker, Character target)
        {
            int damage = Math.Max(0, attacker.AttackPower - target.Defense);
            target.TakeDamage(damage);
            Console.WriteLine($"{attacker.Name} attacks {target.Name} for {damage} damage! {target.Name} Health: {target.Health}");
            return "Attack Complete!";
        }
        public int StartBattle(Character player, Monster enemy)
        {
            while(player.Health > 0 && enemy.Health > 0)
            {
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("player turn");
                Console.WriteLine(Attack(player, enemy));
                if(enemy.Health <= 0)
                {
                    Console.WriteLine("Player Wins");
                    return player.Health;
                }
                Console.WriteLine();
                Console.WriteLine("enemy turn");
                Console.WriteLine(Attack(enemy,player));
                if (player.Health <= 0)
                {
                    Console.WriteLine("Enemy Wins");
                    return enemy.Health;
                }
            }
            return 1;
        }


    }
}
