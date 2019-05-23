class Nightmare : NormalEnemy
{
    public Nightmare()
    {
        LoadImage("data/images/enemies/normal/nightmare.png");

        LifeIncreaser = 17;
        PmIncreaser = 9;
        DamageIncreaser = 19;
        DefenseIncreaser = 9;
        SpeedIncreaser = 3;

        MaxiumLife = LifeIncreaser * Level;
        MaxiumPm = PmIncreaser * Level;
        Damage = DamageIncreaser * Level;
        Defense = DefenseIncreaser * Level;
        Speed = SpeedIncreaser * Level;

        ActualLife = MaxiumLife;
    }
}
