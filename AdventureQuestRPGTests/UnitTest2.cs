using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureQuestRPG;
namespace AdventureQuestRPGTests
{
    public class UnitTest2
    {
        [Fact]
        public void EncounterBossMonsterTest()
        {
            Player player = new Player("player");
            BossMonster boss = new BossMonster("boss");
            Wizard wizard = new Wizard("wizard");
            List<Monster> monsters = new List<Monster> {boss, wizard, wizard, wizard, wizard, wizard};

            foreach (Monster monster in monsters)
            {
                if (monster is BossMonster)
                {
                    Assert.Equal("boss", monster.Name);
                }
            }
        }
        [Fact]
        public void ChangeLocationTest()
        {
            Adventure adventure = new Adventure();
            Location location = new Location("Town");
            adventure.locations.Add(location);
            Assert.Contains(location, adventure.locations);
        }
    }
}
