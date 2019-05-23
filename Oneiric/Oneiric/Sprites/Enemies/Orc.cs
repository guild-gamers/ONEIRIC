class Orc : NormalEnemy
{
    public Orc()
    {
        LoadImage("data/images/enemies/normal/orc.png");

        LifeIncreaser = 33;
        PmIncreaser = 4;
        DamageIncreaser = 8;
        DefenseIncreaser = 16;
        SpeedIncreaser = 2;

        MaxiumLife = LifeIncreaser * Level;
        MaxiumPm = PmIncreaser * Level;
        Damage = DamageIncreaser * Level;
        Defense = DefenseIncreaser * Level;
        Speed = SpeedIncreaser * Level;

        ActualLife = MaxiumLife;
    }
}
