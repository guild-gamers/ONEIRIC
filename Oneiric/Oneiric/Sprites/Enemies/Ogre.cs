class Ogre : NormalEnemy
{
    public Ogre()
    {
        LoadImage("data/images/enemies/normal/ogre.png");

        LifeIncreaser = 33;
        PmIncreaser = 4;
        DamageIncreaser = 16;
        DefenseIncreaser = 8;
        SpeedIncreaser = 2;

        MaxiumLife = LifeIncreaser * Level;
        MaxiumPm = PmIncreaser * Level;
        Damage = DamageIncreaser * Level;
        Defense = DefenseIncreaser * Level;
        Speed = SpeedIncreaser * Level;

        ActualLife = MaxiumLife;
    }
}
