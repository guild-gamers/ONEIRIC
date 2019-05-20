using System;

abstract class InteractibleElement : Sprite
{
    public InteractibleElement(string image)
        :base(image)
    {
    }

    public bool canInteractue(MainCharacter c) {
        //Console.WriteLine(c.GetX() + " - " + x);
        if (((c.GetX() >= x && c.GetX() <= x + 48) ||
            (c.GetX() + 37 >= x && c.GetX() + 37 <= x + 48)) && 
            c.GetY() == y + 48)
            return true;
        else
            return false;
    }
}
