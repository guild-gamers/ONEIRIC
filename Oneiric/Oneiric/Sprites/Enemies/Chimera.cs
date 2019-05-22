class Chimera : NormalEnemy
{
    public Chimera()
    {
        LoadImage("data/images/enemies/normal/chimera.png");

        LifeIncreaser = 44;
        PmIncreaser = 15;
        DamageIncreaser = 8;
        DefenseIncreaser = 14;
        SpeedIncreaser = 5;

        MaxiumLife = LifeIncreaser * Level;
        MaxiumPm = PmIncreaser * Level;
        Damage = DamageIncreaser * Level;
        Defense = DefenseIncreaser * Level;
        Speed = SpeedIncreaser * Level;
    }
}
