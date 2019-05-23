class Succubus : NormalEnemy
{
    public Succubus()
    {
        LoadImage("data/images/enemies/normal/succubus.png");

        LifeIncreaser = 31;
        PmIncreaser = 28;
        DamageIncreaser = 16;
        DefenseIncreaser = 10;
        SpeedIncreaser = 11;

        MaxiumLife = LifeIncreaser * Level;
        MaxiumPm = PmIncreaser * Level;
        Damage = DamageIncreaser * Level;
        Defense = DefenseIncreaser * Level;
        Speed = SpeedIncreaser * Level;

        ActualLife = MaxiumLife;
    }
}
