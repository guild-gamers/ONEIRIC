using System;
using System.Collections.Generic;
using System.IO;

class Chest : InteractibleElement
{
    protected int rarity;
    protected int maxItems;
    protected List<Item> items;
    public Chest(string image, int rarity)
        :base(image)
    {
        this.rarity = rarity;
        maxItems = Game.rand.Next(rarity, rarity*2 + 1);
        SdlHardware.Pause(40);
        items = new List<Item>();
        AddItems();
    }

    public void AddItems()
    {
        while (items.Count == 0)
        {
            try
            {
                StreamReader file = File.OpenText("data/sys/items.dat");
                string line = "";

                do
                {
                    line = file.ReadLine();

                    if (line != null)
                    {
                        string[] data = line.Split(';');

                        if (Convert.ToInt32(data[data.Length - 1]) == rarity)
                        {
                            if (Game.rand.Next(0, 4) == 1)
                            {
                                items.Add(new Item(data[0], Convert.ToInt32(data[1]),
                                    Convert.ToInt32(data[2]), Convert.ToInt32(data[3]),
                                    Convert.ToInt32(data[4]), Convert.ToInt32(data[5])));
                            }
                        }
                    }
                } while (line != null && items.Count < maxItems);

                file.Close();
            }
            catch (PathTooLongException)
            {
                Oneiric.SaveLog("Path too long Error");
            }
            catch (FileNotFoundException)
            {
                Oneiric.SaveLog("File Not Found");
            }
            catch (IOException e)
            {
                Oneiric.SaveLog("IO Error: " + e);
            }
            catch (Exception e)
            {
                Oneiric.SaveLog("Error: " + e);
            }
        }
    }

    public void Interactue(MainCharacter c)
    {
        foreach (Item item in items)
        {
            c.AddItem(item);
        }
        items.Clear();
        LoadImage("data/images/map/computerOn.png");
    }
}
