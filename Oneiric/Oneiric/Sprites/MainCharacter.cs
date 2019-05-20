using System;
using System.Collections.Generic;

class MainCharacter : Character
{
    protected List<Item> inventory;

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
        inventory = new List<Item>();
    }

    public List<Item> GetInventory() { return inventory; }

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
        inventory.Add(i);
    }
}
