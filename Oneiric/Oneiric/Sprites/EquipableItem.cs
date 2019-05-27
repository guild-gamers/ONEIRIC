using System;

[Serializable]
class EquipableItem : Item
{
    public EquipableItem(string name, int lfI, int pmI, int daI, int deI,
        int spI, int luI, int rarity)
        : base(name, lfI, pmI, daI, deI, spI, luI, rarity)
    {

    }
}
