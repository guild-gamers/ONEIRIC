class Puppet : NormalEnemy
{
    public Puppet()
    {
        LoadImage("data/images/enemies/normal/puppet.png");

        LifeIncreaser = 22;
        PmIncreaser = 32;
        DamageIncreaser = 13;
        DefenseIncreaser = 6;
        SpeedIncreaser = 5;

        MaxiumLife = LifeIncreaser * Level;
        MaxiumPm = PmIncreaser * Level;
        Damage = DamageIncreaser * Level;
        Defense = DefenseIncreaser * Level;
        Speed = SpeedIncreaser * Level;

        ActualLife = MaxiumLife;
    }
}
