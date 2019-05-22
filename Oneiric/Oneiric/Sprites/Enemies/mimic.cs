class Mimic : NormalEnemy
{
    public Mimic()
    {
        LoadImage("data/images/enemies/normal/mimic.png");

        LifeIncreaser = 60;
        PmIncreaser = 1;
        DamageIncreaser = 9;
        DefenseIncreaser = 35;
        SpeedIncreaser = 1;

        MaxiumLife = LifeIncreaser * Level;
        MaxiumPm = PmIncreaser * Level;
        Damage = DamageIncreaser * Level;
        Defense = DefenseIncreaser * Level;
        Speed = SpeedIncreaser * Level;
    }
}
