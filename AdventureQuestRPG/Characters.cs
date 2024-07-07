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
        public Player(string name) : base(name)
        {
            SetStats(100, 10, 5);
        }
    }

    public abstract class Monster : Character
    {
        public Monster(string name) : base(name)
        {
        }
    }
    public class Wizard : Monster
    {
        public Wizard(string name) : base(name)
        {
            SetStats(50, 15, 3);
        }
    }
}

