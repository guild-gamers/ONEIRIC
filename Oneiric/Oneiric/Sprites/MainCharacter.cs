using System;
using System.Collections.Generic;

class MainCharacter : Character
{
    public Dictionary<Item,byte> Inventory { get; set; }
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
        Inventory = new Dictionary<Item, byte>();
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
        ActualPm = MaxiumPm;
    }

    public Dictionary<Item,byte> GetInventory() { return Inventory; }

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

    public bool AddItem(Item i)
    {
        bool added = false;
        if (Inventory.ContainsKey(i))
        {
            if (Inventory[i] < 255)
            {
                Inventory[i] += 1;
                added = true;
            }
        }
        else
        {
            Inventory.Add(i,1);
            added = true;
        }

        return added;
    }

    public void UseItem(string itemName) {
        Item i = null;
        foreach(KeyValuePair<Item, byte> it in Inventory) {
            if (it.Key.Name.Substring(0,2) == itemName)
            {
                i = it.Key;
                break;
            }
        }
       
        if (i is ConsumableItem)
        {
            bool used = i.Use();
            if (used)
                Inventory[i] -= 1;

            if (Inventory[i] == 0)
                Inventory.Remove(i);
        }
    }

    public int Heal(int heal) {
        int healedCuantity;
        if (ActualLife + heal > MaxiumLife) {
            healedCuantity = MaxiumLife - ActualLife;
            ActualLife = MaxiumLife;
        }
        else {
            healedCuantity = heal;
            ActualLife += heal;
        }

        return healedCuantity;
    }

    public void Protect()
    {
        Defense *= 2;
    }
}
