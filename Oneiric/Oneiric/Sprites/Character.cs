using System;
using System.Collections.Generic;

abstract class Character : Sprite
{
    public int Level { get; set; }
    public int MaxiumLife { get; set; }
    public int ActualLife { get; set; }
    public int LifeIncreaser { get; set; }
    public int MaxiumPm { get; set; }
    public int ActualPm { get; set; }
    public int PmIncreaser { get; set; }
    public int Damage { get; set; }
    public int DamageIncreaser { get; set; }
    public int Defense { get; set; }
    public int DefenseIncreaser { get; set; }
    public int Speed { get; set; }
    public int SpeedIncreaser { get; set; }
    public int Lucky { get; set; }
    public List<Skill> Skills { get; set; }

    public Character() {}

    public string Attack(Character focus) {
        int damage = Damage + 
            ((Damage/2) * Game.rand.Next(0, Lucky) + 1);
        focus.ActualLife -= damage;
        if (focus.ActualLife < 0)
            focus.ActualLife = 0;
        return damage.ToString();
    }
}
