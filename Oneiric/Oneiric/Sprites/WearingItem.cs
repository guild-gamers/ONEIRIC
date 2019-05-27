using System;

[Serializable]
class WearingItem : EquipableItem
{
    public WearingItem(string name, int lfI, int pmI, int daI, int deI,
        int spI, int luI, int rarity)
        : base(name, lfI, pmI, daI, deI, spI, luI, rarity)
    {

    }
}
