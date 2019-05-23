class NormalEnemy : Enemy
{
    public NormalEnemy() {
        Level = Game.rand.Next(Game.AverageEnemyLevel - 5, Game.AverageEnemyLevel + 6);
    }
}
