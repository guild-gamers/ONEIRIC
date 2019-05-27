using System;
using System.Collections.Generic;
using System.IO;

abstract class Enemy : Character
{
    protected static List<Item> droppableItems;

    public Enemy(){
        droppableItems = new List<Item>();
        LoadItems();
    }

    public Item DropItem()
    {
        if (Game.rand.Next(0, 2) == 1) {
            return droppableItems[Game.rand.Next(0, droppableItems.Count)];
        }

        return null;
    }

    public void LoadItems()
    {
        try
        {
            StreamReader file = File.OpenText("data/langs/" +
                Oneiric.Languages[Oneiric.Language].Substring(
                    0, 2).ToLower() + "/items.dat/");

            string line = "";

            do
            {
                line = file.ReadLine();

                if (line != null)
                {
                    string[] data = line.Split(';');
                    if (data[0] == "c")
                    {
                        droppableItems.Add(new ConsumableItem(data[1], Convert.ToInt32(data[2]),
                            Convert.ToInt32(data[3]), Convert.ToInt32(data[4]),
                            Convert.ToInt32(data[5]), Convert.ToInt32(data[6]),
                            Convert.ToInt32(data[7]), Convert.ToInt32(data[8]),
                            Convert.ToInt32(data[9])));
                    }
                    else if (data[0] == "e")
                    {
                        droppableItems.Add(new EquipableItem(data[1], Convert.ToInt32(data[2]),
                            Convert.ToInt32(data[3]), Convert.ToInt32(data[4]),
                            Convert.ToInt32(data[5]), Convert.ToInt32(data[6]),
                            Convert.ToInt32(data[7]), Convert.ToInt32(data[8])));
                    }
                    else
                    {
                        droppableItems.Add(new Item(data[1], Convert.ToInt32(data[2]),
                            Convert.ToInt32(data[3]), Convert.ToInt32(data[4]),
                            Convert.ToInt32(data[5]), Convert.ToInt32(data[6]),
                            Convert.ToInt32(data[7]), Convert.ToInt32(data[8])));
                    }
                }
            } while (line != null);
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
