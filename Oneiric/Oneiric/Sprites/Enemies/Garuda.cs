class Garuda : NormalEnemy
{
    public Garuda()
    {
        LoadImage("data/images/enemies/normal/garuda.png");

        LifeIncreaser = 32;
        PmIncreaser = 21;
        DamageIncreaser = 12;
        DefenseIncreaser = 4;
        SpeedIncreaser = 11;

        MaxiumLife = LifeIncreaser * Level;
        MaxiumPm = PmIncreaser * Level;
        Damage = DamageIncreaser * Level;
        Defense = DefenseIncreaser * Level;
        Speed = SpeedIncreaser * Level;

        ActualLife = MaxiumLife;
    }
}
