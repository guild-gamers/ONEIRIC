class Item : Sprite
{
    protected string name;
    protected int damageIncreaser;
    protected int defenseIncreaser;
    protected int speedIncreaser;
    protected int luckyIncreaser;
    protected int rarity;

    public Item(string name, int daI, int deI, int spI, int luI, int rarity)
    {
        this.name = name;
        damageIncreaser = daI;
        defenseIncreaser = deI;
        speedIncreaser = spI;
        luckyIncreaser = luI;
        this.rarity = rarity;
    }
}
