class NightmareSoldier : NormalEnemy
{
    public NightmareSoldier()
    {
        LoadImage("data/images/enemies/normal/nightmaresoldier.png");

        LifeIncreaser = 35;
        PmIncreaser = 4;
        DamageIncreaser = 10;
        DefenseIncreaser = 10;
        SpeedIncreaser = 5;

        MaxiumLife = LifeIncreaser * Level;
        MaxiumPm = PmIncreaser * Level;
        Damage = DamageIncreaser * Level;
        Defense = DefenseIncreaser * Level;
        Speed = SpeedIncreaser * Level;

        ActualLife = MaxiumLife;
    }
}
