class Ghost : NormalEnemy
{
    public Ghost()
    {
        LoadImage("data/images/enemies/normal/ghost.png");

        LifeIncreaser = 28;
        PmIncreaser = 18;
        DamageIncreaser = 14;
        DefenseIncreaser = 8;
        SpeedIncreaser = 6;

        MaxiumLife = LifeIncreaser * Level;
        MaxiumPm = PmIncreaser * Level;
        Damage = DamageIncreaser * Level;
        Defense = DefenseIncreaser * Level;
        Speed = SpeedIncreaser * Level;
    }
}
