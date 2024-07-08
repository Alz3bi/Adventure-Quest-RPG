using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureQuestRPG
{
    public class Character : IBattleStates
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }
        public Character(string name)
        {
            Name = name;

        }
        public void SetStats(int health, int attackPower, int defense)
        {
            Health = health;
            AttackPower = attackPower;
            Defense = defense;
        }
        public void TakeDamage(int damage)
        {
            Health = Math.Max(0, Health - damage);
        }
    }
    public class Player : Character
    {
        public int HealthCap { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }
        public int XpCap { get; set; }
        public Player(string name) : base(name)
        {
            XpCap = 100;
            HealthCap = 100;
            SetStats(HealthCap, 10, 5);
            Level = 1;
            XP = 0;
        }
        public void restoreHealth()
        {
            Health = HealthCap;
        }
        public void GainXP(int xp)
        {
            XP += xp;
            while (XP >= XpCap)
            {
                Level++;
                LevelUp();
                XP = XP - 100;
                Console.Clear();
                Console.WriteLine($"You leveled up to level {Level}!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                XpCap += 50;
            }
        }
        public void LevelUp()
        {
            HealthCap += 10;
            SetStats(HealthCap, AttackPower + 2, Defense + 1);
        }
    }

    public abstract class Monster : Character
    {
        public int DefeatXp { get; set; }
        public Monster(string name) : base(name)
        {
        }
    }
    public class Wizard : Monster
    {
        public Wizard(string name) : base(name)
        {
            DefeatXp = 100;
            SetStats(50, 15, 3);
        }
    }
    public class BossMonster : Monster
    {
        public BossMonster(string name) : base(name)
        {
            DefeatXp = 500;
            SetStats(200, 20, 10);
        }
    }
}

