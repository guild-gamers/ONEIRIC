class Werewolf : NormalEnemy
{
    public Werewolf()
    {
        LoadImage("data/images/enemies/normal/werewolf.png");

        LifeIncreaser = 37;
        PmIncreaser = 12;
        DamageIncreaser = 19;
        DefenseIncreaser = 9;
        SpeedIncreaser = 13;

        MaxiumLife = LifeIncreaser * Level;
        MaxiumPm = PmIncreaser * Level;
        Damage = DamageIncreaser * Level;
        Defense = DefenseIncreaser * Level;
        Speed = SpeedIncreaser * Level;

        ActualLife = MaxiumLife;
    }
}
