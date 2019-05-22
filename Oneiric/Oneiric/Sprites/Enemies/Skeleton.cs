class Skeleton : NormalEnemy
{
    public Skeleton()
    {
        LoadImage("data/images/enemies/normal/skeleton.png");

        LifeIncreaser = 19;
        PmIncreaser = 29;
        DamageIncreaser = 15;
        DefenseIncreaser = 5;
        SpeedIncreaser = 6;

        MaxiumLife = LifeIncreaser * Level;
        MaxiumPm = PmIncreaser * Level;
        Damage = DamageIncreaser * Level;
        Defense = DefenseIncreaser * Level;
        Speed = SpeedIncreaser * Level;
    }
}
