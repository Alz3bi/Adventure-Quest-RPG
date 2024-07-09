using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureQuestRPG
{
    public class Inventory
    {
        public List<Items> Items { get; set; } = new List<Items>();
        public Inventory() { }
        public void AddItem(Items item)
        {
            Items.Add(item);
        }
        public void RemoveItem(Items item)
        {
            Items.Remove(item);
        }
        public void DisplayInventory()
        {
            Console.WriteLine("Inventory:");
            int index = 1;
            foreach (Items item in Items)
            {
                if(item.IsEquipped)
                {
                    Console.WriteLine($"{index}. {item.Name} - {item.Description} - Equipped");
                }
                else
                Console.WriteLine($"{index}. {item.Name} - {item.Description}");
                index++;
            }
            if (Items.Count == 0)
            {
                Console.WriteLine("Inventory is empty");
            }
        }
        public void DisplayUnequippedItems()
        {
            Console.WriteLine("Inventory:");
            int index = 1;
            foreach (Items item in Items)
            {
                if (!item.IsEquipped)
                {
                    Console.WriteLine($"{index}. {item.Name} - {item.Description}");
                }
                index++;
            }
            if (Items.Count == 0)
            {
                Console.WriteLine("Inventory is empty");
            }
        }

    }
}
