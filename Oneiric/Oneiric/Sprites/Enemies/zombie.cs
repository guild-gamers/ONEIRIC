class Zombie : NormalEnemy
{
    public Zombie()
    {
        LoadImage("data/images/enemies/normal/zombie.png");

        LifeIncreaser = 21;
        PmIncreaser = 28;
        DamageIncreaser = 23;
        DefenseIncreaser = 5;
        SpeedIncreaser = 5;

        MaxiumLife = LifeIncreaser * Level;
        MaxiumPm = PmIncreaser * Level;
        Damage = DamageIncreaser * Level;
        Defense = DefenseIncreaser * Level;
        Speed = SpeedIncreaser * Level;

        ActualLife = MaxiumLife;
    }
}
