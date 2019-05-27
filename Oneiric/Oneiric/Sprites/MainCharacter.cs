using System;
using System.Collections.Generic;

class MainCharacter : Character
{
    public List<Item> Inventory { get; set; }
    public List<Weapon> Weapons { get; set; }
    public string Name { get; }

    public MainCharacter()
    {
        LoadSequence(RIGHT,
            new string[] { "data/images/Player/Right_1.png",
                "data/images/Player/Right_2.png",
                "data/images/Player/Right_3.png"  });
        LoadSequence(LEFT,
            new string[] { "data/images/Player/Left_1.png",
                "data/images/Player/Left_2.png",
                "data/images/Player/Left_3.png"});
        LoadSequence(UP,
            new string[] { "data/images/Player/Up_1.png",
                "data/images/Player/Up_2.png",
                "data/images/Player/Up_3.png" });
        LoadSequence(DOWN,
            new string[] { "data/images/Player/Down_1.png",
                "data/images/Player/Down_2.png",
                "data/images/Player/Down_3.png" });
        currentDirection = UP;
        x = 240;
        y = 320;
        xSpeed = ySpeed = 8;
        width = 37;
        height = 47;
        Inventory = new List<Item>();
        Name = "Coco";
        Level = 10;
        LifeIncreaser = 25;
        PmIncreaser = 20;
        DamageIncreaser = 9;
        DefenseIncreaser = 9;
        SpeedIncreaser = 5;

        MaxiumLife = LifeIncreaser * Level;
        MaxiumPm = PmIncreaser * Level;
        Damage = DamageIncreaser * Level;
        Defense = DefenseIncreaser * Level;
        Speed = SpeedIncreaser * Level;

        ActualLife = MaxiumLife;
    }

    public List<Item> GetInventory() { return Inventory; }

    public void MoveRight()
    {
        x += xSpeed;
        NextFrame();
    }

    public void MoveLeft()
    {
        x -= xSpeed;
        NextFrame();
    }

    public void MoveUp()
    {
        y -= ySpeed;
        NextFrame();
    }

    public void MoveDown()
    {
        y += ySpeed;
        NextFrame();
    }

    public void AddItem(Item i)
    {
        Inventory.Add(i);
    }
}
