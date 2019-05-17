using System;
using System.Collections.Generic;
using System.IO;

class Chest : InteractibleElement
{
    protected int rarity;
    protected int maxItems;
    protected List<Item> items;
    protected Random r;
    public Chest(int rarity)
    {
        this.rarity = rarity;
        r = new Random();
        maxItems = r.Next(rarity, rarity*2);
        items = new List<Item>();
        AddItems();
    }

    public void AddItems()
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

                    if (Convert.ToInt32(data[data.Length-1]) == rarity)
                    {
                        if (r.Next(0, 1) == 0)
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
        catch (Exception)
        {

            throw;
        }
    }
}
