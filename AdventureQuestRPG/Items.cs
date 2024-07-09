using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureQuestRPG
{
    public abstract class Items
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEquipped { get; set; }

        public Items(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
    public class Weapon : Items
    {
        public int AttackPower { get; set; }
        public Weapon(string name, string description, int attackPower) : base(name, description)
        {
            Name = name;
            AttackPower = attackPower;
        }
    }
    public class Armor : Items
    {
        public int Defense { get; set; }
        public Armor(string name, string description, int defense) : base(name, description)
        {
            Name = name;
            Defense = defense;
        }
    }
    public class Consumable : Items
    {
        public int HealthRestore { get; set; }
        public Consumable(string name, string description, int healthRestore) : base(name, description)
        {
            Name = name;
            HealthRestore = healthRestore;
        }
    }
}
