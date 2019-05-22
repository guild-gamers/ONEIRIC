class NormalEnemy : Enemy
{
    public NormalEnemy() {
        Level = Game.rand.Next(Game.AverageEnemyLevenl - 5, Game.AverageEnemyLevenl + 6);
    }
}
