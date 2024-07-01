using AdventureQuestRPG;
namespace AdventureQuestRPGTests
{
    public class UnitTest1
    {
        [Fact]
        public void PlayerAttackEnemyTest()
        {
            // Arrange
            Player player = new Player("Player");
            Wizard enemy = new Wizard("Enemy");
            BattleSystem battleSystem = new BattleSystem();

            // Act
            battleSystem.Attack(player, enemy);
            int result = enemy.Health;

            // Assert
            Assert.Equal(43, result);
        }
        [Fact]
        public void EnemyAttackPlayerTest()
        {
            // Arrange
            Player player = new Player("Player");
            Wizard enemy = new Wizard("Enemy");
            BattleSystem battleSystem = new BattleSystem();

            // Act
            battleSystem.Attack(enemy, player);
            int result = player.Health;

            // Assert
            Assert.Equal(90, result);
        }
        [Fact]
        public void WinnerHealthTest()
        {
            // Arrange
            Player player = new Player("Player");
            Wizard enemy = new Wizard("Enemy");
            BattleSystem battleSystem = new BattleSystem();

            // Act
            int WinnerHealth = battleSystem.StartBattle(player, enemy);
            //int playerHealth = player.Health;
            //int enemyHealth = enemy.Health;

            // Assert
            Assert.True(WinnerHealth > 0);
        }
    }
}