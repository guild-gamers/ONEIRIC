class Item : Sprite
{
    public string Name { get; set; }
    public int DamageIncreaser { get; set; }
    public int DefenseIncreaser { get; set; }
    public int SpeedIncreaser { get; set; }
    public int LuckyIncreaser { get; set; }
    public int Rarity { get; set; }

    public Item(string name, int daI, int deI, int spI, int luI, int rarity)
    {
        Name = name;
        DamageIncreaser = daI;
        DefenseIncreaser = deI;
        SpeedIncreaser = spI;
        LuckyIncreaser = luI;
        Rarity = rarity;
    }
}
