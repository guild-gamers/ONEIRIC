class Vampire : NormalEnemy
{
    public Vampire()
    {
        LoadImage("data/images/enemies/normal/vampire.png");

        LifeIncreaser = 37;
        PmIncreaser = 25;
        DamageIncreaser = 13;
        DefenseIncreaser = 7;
        SpeedIncreaser = 10;

        MaxiumLife = LifeIncreaser * Level;
        MaxiumPm = PmIncreaser * Level;
        Damage = DamageIncreaser * Level;
        Defense = DefenseIncreaser * Level;
        Speed = SpeedIncreaser * Level;
    }
}
