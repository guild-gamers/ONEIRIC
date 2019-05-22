class Brigthrooster : NormalEnemy
{
    public Brigthrooster()
    {
        LoadImage("data/images/enemies/normal/birghtrooster.png");

        LifeIncreaser = 21;
        PmIncreaser = 17;
        DamageIncreaser = 5;
        DefenseIncreaser = 6;
        SpeedIncreaser = 16;

        MaxiumLife = LifeIncreaser * Level;
        MaxiumPm = PmIncreaser * Level;
        Damage = DamageIncreaser * Level;
        Defense = DefenseIncreaser * Level;
        Speed = SpeedIncreaser * Level;
    }
}
